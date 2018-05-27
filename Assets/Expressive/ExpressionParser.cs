﻿using Expressive.Exceptions;
using Expressive.Expressions;
using Expressive.Functions;
using Expressive.Functions.Date;
using Expressive.Functions.Logical;
using Expressive.Functions.Mathematical;
using Expressive.Functions.Statistical;
using Expressive.Functions.String;
using Expressive.Operators;
using Expressive.Operators.Additive;
using Expressive.Operators.Bitwise;
using Expressive.Operators.Conditional;
using Expressive.Operators.Grouping;
using Expressive.Operators.Logic;
using Expressive.Operators.Multiplicative;
using Expressive.Operators.Relational;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Expressive
{

    internal static class StringUtils {
        internal static bool IsNullOrWhiteSpace(string test) {
            return test == null || test.Trim().Equals("");
        }
    }

    internal sealed class ExpressionParser
    {
        #region Constants

        private const char DateSeparator = '#';
        //private const char DecimalSeparator = '.';
        private const char ParameterSeparator = ',';

        #endregion

        #region Fields

        private readonly char _decimalSeparator;
        private readonly ExpressiveOptions _options;
        private readonly IDictionary<string, Func<IExpression[], IDictionary<string, object>, object>> _registeredFunctions;
        private readonly IDictionary<string, IOperator> _registeredOperators;
        private readonly StringComparer _stringComparer;

        #endregion

        #region Constructors

        internal ExpressionParser(ExpressiveOptions options)
        {
            _options = options;

            // Initialise the string comparer only once.
            _stringComparer = _options.HasFlag(ExpressiveOptions.IgnoreCase) ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;

            _decimalSeparator = Convert.ToChar(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            _registeredFunctions = new Dictionary<string, Func<IExpression[], IDictionary<string, object>, object>>(GetDictionaryComparer(options));
            _registeredOperators = new Dictionary<string, IOperator>(GetDictionaryComparer(options));

            #region Operators
            // TODO: Do we allow for turning off operators?
            // Additive
            RegisterOperator(new PlusOperator());
            RegisterOperator(new SubtractOperator());
            // Bitwise
            RegisterOperator(new BitwiseAndOperator());
            RegisterOperator(new BitwiseOrOperator());
            RegisterOperator(new BitwiseXOrOperator());
            RegisterOperator(new LeftShiftOperator());
            RegisterOperator(new RightShiftOperator());
            // Conditional
            RegisterOperator(new NullCoalescingOperator());
            // Grouping
            RegisterOperator(new ParenthesisCloseOperator());
            RegisterOperator(new ParenthesisOpenOperator());
            // Logic
            RegisterOperator(new AndOperator());
            RegisterOperator(new NotOperator());
            RegisterOperator(new OrOperator());
            // Multiplicative
            RegisterOperator(new DivideOperator());
            RegisterOperator(new ModulusOperator());
            RegisterOperator(new MultiplyOperator());
            // Relational
            RegisterOperator(new EqualOperator());
            RegisterOperator(new GreaterThanOperator());
            RegisterOperator(new GreaterThanOrEqualOperator());
            RegisterOperator(new LessThanOperator());
            RegisterOperator(new LessThanOrEqualOperator());
            RegisterOperator(new NotEqualOperator());
            #endregion

            #region Functions

            if (Expression.dateFuncEnable) {
                // Date
                RegisterFunction(new AddDaysFunction());
                RegisterFunction(new AddHoursFunction());
                RegisterFunction(new AddMillisecondsFunction());
                RegisterFunction(new AddMinutesFunction());
                RegisterFunction(new AddMonthsFunction());
                RegisterFunction(new AddSecondsFunction());
                RegisterFunction(new AddYearsFunction());
                RegisterFunction(new DayOfFunction());
                RegisterFunction(new DaysBetweenFunction());
                RegisterFunction(new HourOfFunction());
                RegisterFunction(new HoursBetweenFunction());
                RegisterFunction(new MillisecondOfFunction());
                RegisterFunction(new MillisecondsBetweenFunction());
                RegisterFunction(new MinuteOfFunction());
                RegisterFunction(new MinutesBetweenFunction());
                RegisterFunction(new MonthOfFunction());
                RegisterFunction(new SecondOfFunction());
                RegisterFunction(new SecondsBetweenFunction());
                RegisterFunction(new YearOfFunction());
            }
            // Mathematical
            RegisterFunction(new AbsFunction());
            RegisterFunction(new AcosFunction());
            RegisterFunction(new AsinFunction());
            RegisterFunction(new AtanFunction());
            RegisterFunction(new CeilingFunction());
            RegisterFunction(new CosFunction());
            RegisterFunction(new CountFunction());
            RegisterFunction(new ExpFunction());
            RegisterFunction(new FloorFunction());
            RegisterFunction(new IEEERemainderFunction());
            RegisterFunction(new Log10Function());
            RegisterFunction(new LogFunction());
            RegisterFunction(new MaxFunction());
            RegisterFunction(new MinFunction());
            RegisterFunction(new PowFunction());
            RegisterFunction(new RandomFunction());
            RegisterFunction(new RoundFunction());
            RegisterFunction(new SignFunction());
            RegisterFunction(new SinFunction());
            RegisterFunction(new SqrtFunction());
            RegisterFunction(new SumFunction());
            RegisterFunction(new TanFunction());
            RegisterFunction(new TruncateFunction());
            // Logical
            RegisterFunction(new IfFunction());
            RegisterFunction(new InFunction());
            // Statistical
            RegisterFunction(new AverageFunction());
            RegisterFunction(new MeanFunction());
            RegisterFunction(new MedianFunction());
            RegisterFunction(new ModeFunction());

            if (Expression.stringFuncEnable) {
            // String
                RegisterFunction(new ContainsFunction());
                RegisterFunction(new EndsWithFunction());
                RegisterFunction(new LengthFunction());
                RegisterFunction(new PadLeftFunction());
                RegisterFunction(new PadRightFunction());
                RegisterFunction(new RegexFunction());
                RegisterFunction(new StartsWithFunction());
                RegisterFunction(new SubstringFunction()); 
            }           
            #endregion
        }

        #endregion

        #region Internal Methods

        internal IExpression CompileExpression(string expression, IList<string> variables)
        {
            if (StringUtils.IsNullOrWhiteSpace(expression))
            {
                throw new ExpressiveException("An Expression cannot be empty.");
            }

            var tokens = Tokenise(expression);

            var openCount = tokens.Select(t => t.CurrentToken).Count(t => string.Equals(t, "(", StringComparison.Ordinal));
            var closeCount = tokens.Select(t => t.CurrentToken).Count(t => string.Equals(t, ")", StringComparison.Ordinal));

            // Bail out early if there isn't a matching set of ( and ) characters.
            if (openCount > closeCount)
            {
                throw new ArgumentException("There aren't enough ')' symbols. Expected " + openCount + " but there is only " + closeCount);
            }
            else if (openCount < closeCount)
            {
                throw new ArgumentException("There are too many ')' symbols. Expected " + openCount + " but there is " + closeCount);
            }

            return CompileExpression(new Queue<Token>(tokens), OperatorPrecedence.Minimum, variables, false);
        }

        internal void RegisterFunction(string functionName, Func<IExpression[], IDictionary<string, object>, object> function)
        {
            CheckForExistingFunctionName(functionName);

            _registeredFunctions.Add(functionName, function);
        }

        internal void RegisterFunction(IFunction function)
        {
            CheckForExistingFunctionName(function.Name);

            _registeredFunctions.Add(function.Name, (p, a) =>
            {
                function.Variables = a;

                return function.Evaluate(p, _options);
            });
        }

        internal void RegisterOperator(IOperator op)
        {
            foreach (var tag in op.Tags)
            {
                _registeredOperators.Add(tag, op);
            }
        }

        internal void UnregisterFunction(string name)
        {
            if (_registeredFunctions.ContainsKey(name))
            {
                _registeredFunctions.Remove(name);
            }
        }

        #endregion

        #region Private Methods

        private IExpression CompileExpression(Queue<Token> tokens, OperatorPrecedence minimumPrecedence, IList<string> variables, bool isWithinFunction)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException("tokens", "You must call Tokenise before compiling");
            }
            
            IExpression leftHandSide = null;
            var currentToken = tokens.PeekOrDefault();
            Token previousToken = null;

            while (currentToken != null)
            {
                Func<IExpression[], IDictionary<string, object>, object> function = null;
                IOperator op = null;

                if (_registeredOperators.TryGetValue(currentToken.CurrentToken, out op)) // Are we an IOperator?
                {
                    var precedence = op.GetPrecedence(previousToken);

                    if (precedence > minimumPrecedence)
                    {
                        tokens.Dequeue();

                        if (!op.CanGetCaptiveTokens(previousToken, currentToken, tokens))
                        {
                            // Do it anyway to update the list of tokens
                            op.GetCaptiveTokens(previousToken, currentToken, tokens);
                            break;
                        }
                        else
                        {
                            IExpression rightHandSide = null;

                            var captiveTokens = op.GetCaptiveTokens(previousToken, currentToken, tokens);

                            if (captiveTokens.Length > 1)
                            {
                                var innerTokens = op.GetInnerCaptiveTokens(captiveTokens);
                                rightHandSide = CompileExpression(new Queue<Token>(innerTokens), OperatorPrecedence.Minimum, variables, isWithinFunction);

                                currentToken = captiveTokens[captiveTokens.Length - 1];
                            }
                            else
                            {
                                rightHandSide = CompileExpression(tokens, precedence, variables, isWithinFunction);
                                // We are at the end of an expression so fake it up.
                                currentToken = new Token(")", -1);
                            }

                            leftHandSide = op.BuildExpression(previousToken, new[] { leftHandSide, rightHandSide }, _options);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (_registeredFunctions.TryGetValue(currentToken.CurrentToken, out function)) // or an IFunction?
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    var expressions = new List<IExpression>();
                    var captiveTokens = new Queue<Token>();
                    var parenCount = 0;
                    tokens.Dequeue();

                    // Loop through the list of tokens and split by ParameterSeparator character
                    while (tokens.Count > 0)
                    {
                        var nextToken = tokens.Dequeue();

                        if (string.Equals(nextToken.CurrentToken, "(", StringComparison.Ordinal))
                        {
                            parenCount++;
                        }
                        else if (string.Equals(nextToken.CurrentToken, ")", StringComparison.Ordinal))
                        {
                            parenCount--;
                        }

                        if (!(parenCount == 1 && nextToken.CurrentToken == "(") &&
                                !(parenCount == 0 && nextToken.CurrentToken == ")"))
                        {
                            captiveTokens.Enqueue(nextToken);
                        }

                        if (parenCount == 0 &&
                            captiveTokens.Any())
                        {
                            expressions.Add(CompileExpression(captiveTokens, minimumPrecedence: OperatorPrecedence.Minimum, variables: variables, isWithinFunction: true));
                            captiveTokens.Clear();
                        }
                        else if (string.Equals(nextToken.CurrentToken, ParameterSeparator.ToString(), StringComparison.Ordinal) && parenCount == 1)
                        {
                            // TODO: Should we expect expressions to be null???
                            expressions.Add(CompileExpression(captiveTokens, minimumPrecedence: 0, variables: variables, isWithinFunction: true));
                            captiveTokens.Clear();
                        }

                        if (parenCount <= 0)
                        {
                            break;
                        }
                    }

                    leftHandSide = new FunctionExpression(currentToken.CurrentToken, function, expressions.ToArray());
                }
                else if (currentToken.CurrentToken.IsNumeric()) // Or a number
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();
                    int intValue = 0;
                    decimal decimalValue = 0.0M;
                    double doubleValue = 0.0;
                    float floatValue = 0.0f;
                    long longValue = 0;

                    if (int.TryParse(currentToken.CurrentToken, out intValue))
                    {
                        leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Integer, intValue);
                    }
                    else if (decimal.TryParse(currentToken.CurrentToken, out decimalValue))
                    {
                        leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Decimal, decimalValue);
                    }
                    else if (double.TryParse(currentToken.CurrentToken, out doubleValue))
                    {
                        leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Double, doubleValue);
                    }
                    else if (float.TryParse(currentToken.CurrentToken, out floatValue))
                    {
                        leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Float, floatValue);
                    }
                    else if (long.TryParse(currentToken.CurrentToken, out longValue))
                    {
                        leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Long, longValue);
                    }
                }
                else if (currentToken.CurrentToken.StartsWith("[") && currentToken.CurrentToken.EndsWith("]")) // or a variable?
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();
                    string variableName = currentToken.CurrentToken.Replace("[", "").Replace("]", "");
                    leftHandSide = new VariableExpression(variableName);

                    if (!variables.Contains(variableName, _stringComparer))
                    {
                        variables.Add(variableName);
                    }
                }
                else if (string.Equals(currentToken.CurrentToken, "true", StringComparison.OrdinalIgnoreCase)) // or a boolean?
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();
                    leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Boolean, true);
                }
                else if (string.Equals(currentToken.CurrentToken, "false", StringComparison.OrdinalIgnoreCase))
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();
                    leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Boolean, false);
                }
                else if (string.Equals(currentToken.CurrentToken, "null", StringComparison.OrdinalIgnoreCase)) // or a null?
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();
                    leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Null, null);
                }
                else if (currentToken.CurrentToken.StartsWith(DateSeparator.ToString()) && currentToken.CurrentToken.EndsWith(DateSeparator.ToString())) // or a date?
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();

                    string dateToken = currentToken.CurrentToken.Replace(DateSeparator.ToString(), "");
                    DateTime date = DateTime.MinValue;
                    
                    // If we can't parse the date let's check for some known tags.
                    if (!DateTime.TryParse(dateToken, out date))
                    {
                        if (string.Equals("TODAY", dateToken, StringComparison.OrdinalIgnoreCase))
                        {
                            date = DateTime.Today;
                        }
                        else if (string.Equals("NOW", dateToken, StringComparison.OrdinalIgnoreCase))
                        {
                            date = DateTime.Now;
                        }
                        else
                        {
                            throw new UnrecognisedTokenException(dateToken);
                        }
                    }

                    leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.DateTime, date);
                }
                else if ((currentToken.CurrentToken.StartsWith("'") && currentToken.CurrentToken.EndsWith("'")) ||
                    (currentToken.CurrentToken.StartsWith("\"") && currentToken.CurrentToken.EndsWith("\"")))
                {
                    this.CheckForExistingParticipant(leftHandSide, currentToken, isWithinFunction);

                    tokens.Dequeue();
                    leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.String, CleanString(currentToken.CurrentToken.Substring(1, currentToken.Length - 2)));
                }
                else if (string.Equals(currentToken.CurrentToken, ParameterSeparator.ToString(), StringComparison.Ordinal)) // Make sure we ignore the parameter separator
                {
                    // TODO should we throw an exception if we are not within a function?
                    if (!isWithinFunction)
                    {
                        throw new ExpressiveException("Unexpected token '" + currentToken + "'");
                    }
                    tokens.Dequeue();

                    //throw new InvalidOperationException("Unrecognised token '" + currentToken + "'");

                    //if (!string.Equals(currentToken, ParameterSeparator.ToString(), StringComparison.Ordinal)) // Make sure we ignore the parameter separator
                    //{
                    //    currentToken = CleanString(currentToken);

                    //    leftHandSide = new ConstantValueExpression(ConstantValueExpressionType.Unknown, currentToken);
                    //}
                }
                else
                {
                    tokens.Dequeue();

                    throw new UnrecognisedTokenException(currentToken.CurrentToken);
                }

                previousToken = currentToken;
                currentToken = tokens.PeekOrDefault();
            }

            return leftHandSide;
        }

        private static string CleanString(string input)
        {
            if (input.Length <= 1) return input;

            // the input string can only get shorter
            // so init the buffer so we won't have to reallocate later
            char[] buffer = new char[input.Length];
            int outIdx = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '\\')
                {
                    if (i < input.Length - 1)
                    {
                        switch (input[i + 1])
                        {
                            case 'n':
                                buffer[outIdx++] = '\n';
                                i++;
                                continue;
                            case 'r':
                                buffer[outIdx++] = '\r';
                                i++;
                                continue;
                            case 't':
                                buffer[outIdx++] = '\t';
                                i++;
                                continue;
                            case '\'':
                                buffer[outIdx++] = '\'';
                                i++;
                                continue;
                        }
                    }
                }

                buffer[outIdx++] = c;
            }

            return new string(buffer, 0, outIdx);
        }

        private static bool CanExtractValue(string expression, int expressionLength, int index, string value)
        {
            return string.Equals(value, ExtractValue(expression, expressionLength, index, value), StringComparison.OrdinalIgnoreCase);
        }

        private static bool CanGetString(string expression, int startIndex, char quoteCharacter)
        {
            return !StringUtils.IsNullOrWhiteSpace(GetString(expression, startIndex, quoteCharacter));
        }

        private void CheckForExistingFunctionName(string functionName)
        {
            if (_registeredFunctions.ContainsKey(functionName))
            {
                throw new FunctionNameAlreadyRegisteredException(functionName);
            }
        }

        private void CheckForExistingParticipant(IExpression participant, Token token, bool isWithinFunction)
        {
            if (participant != null)
            {
                if (isWithinFunction)
                {
                    throw new MissingTokenException("Missing token, expecting ','.", ',');
                }
                
                throw new ExpressiveException("Unexpected token '" + token.CurrentToken +"' at index " + token.StartIndex);
            }
        }

        private static bool CheckForTag(string tag, string lookAhead, ExpressiveOptions options)
        {
            return (options.HasFlag(ExpressiveOptions.IgnoreCase) &&
                string.Equals(lookAhead, tag, StringComparison.OrdinalIgnoreCase)) ||
                string.Equals(lookAhead, tag, StringComparison.Ordinal);
        }

        private static string ExtractValue(string expression, int expressionLength, int index, string expectedValue)
        {
            string result = null;
            int valueLength = expectedValue.Length;

            if (expressionLength >= index + valueLength)
            {
                var valueString = expression.Substring(index, valueLength);
                bool isValidValue = true;
                if (expressionLength > index + valueLength)
                {
                    // If the next character is not a continuation of the word then we are valid.
                    isValidValue = !char.IsLetterOrDigit(expression[index + valueLength]);
                }

                if (string.Equals(valueString, expectedValue, StringComparison.OrdinalIgnoreCase) &&
                    isValidValue)
                {
                    result = valueString;
                }
            }

            return result;
        }

        private StringComparer GetDictionaryComparer(ExpressiveOptions options)
        {
            return options.HasFlag(ExpressiveOptions.IgnoreCase) ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
        }

        private string GetNumber(string expression, int startIndex)
        {
            bool hasDecimalPoint = false;
            var index = startIndex;
            var character = expression[index];

            while ((index < expression.Length) &&
                (char.IsDigit(character) || (!hasDecimalPoint && character == _decimalSeparator)))
            {
                if (!hasDecimalPoint && character == _decimalSeparator)
                {
                    hasDecimalPoint = true;
                }

                index++;

                if (index == expression.Length)
                {
                    break;
                }

                character = expression[index];
            }

            return expression.Substring(startIndex, index - startIndex);
        }

        private static string GetString(string expression, int startIndex, char quoteCharacter)
        {
            int index = startIndex;
            bool foundEndingQuote = false;
            var character = expression[index];
            var previousCharacter = char.MinValue;

            while (index < expression.Length && !foundEndingQuote)
            {
                if (index != startIndex &&
                    character == quoteCharacter &&
                    previousCharacter != '\\') // Make sure the escape character wasn't previously used.
                {
                    foundEndingQuote = true;
                }

                previousCharacter = character;
                index++;

                if (index == expression.Length)
                {
                    break;
                }

                character = expression[index];
            }

            if (foundEndingQuote)
            {
                return expression.Substring(startIndex, index - startIndex);
            }

            return null;
        }

        private static bool IsQuote(char character)
        {
            return character == '\'' || character == '\"';
        }

        private IList<Token> Tokenise(string expression)
        {
            if (StringUtils.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            var expressionLength = expression.Length;
            var operators = _registeredOperators.OrderByDescending(op => op.Key.Length);
            var tokens = new List<Token>();
            IList<char> unrecognised = null;

            var index = 0;

            while (index < expressionLength)
            {
                var lengthProcessed = 0;
                bool foundUnrecognisedCharacter = false;

                // Functions would tend to have longer tags so check for these first.
                foreach (var kvp in _registeredFunctions.OrderByDescending(f => f.Key.Length))
                {
                    var lookAhead = expression.Substring(index, Math.Min(kvp.Key.Length, expressionLength - index));

                    if (CheckForTag(kvp.Key, lookAhead, _options))
                    {
                        CheckForUnrecognised(unrecognised, tokens, index);
                        lengthProcessed = kvp.Key.Length;
                        tokens.Add(new Token(lookAhead, index));
                        break;
                    }
                }

                if (lengthProcessed == 0)
                {
                    // Loop through and find any matching operators.
                    foreach (var op in operators)
                    {
                        var lookAhead = expression.Substring(index, Math.Min(op.Key.Length, expressionLength - index));

                        if (CheckForTag(op.Key, lookAhead, _options))
                        {
                            CheckForUnrecognised(unrecognised, tokens, index);
                            lengthProcessed = op.Key.Length;
                            tokens.Add(new Token(lookAhead, index));
                            break;
                        }
                    }
                }

                // If an operator wasn't found then process the current character.
                if (lengthProcessed == 0)
                {
                    var character = expression[index];

                    if (character == '[')
                    {
                        char closingCharacter = ']';

                        if (!CanGetString(expression, index, closingCharacter))
                        {
                            throw new MissingTokenException("Missing closing token '" + closingCharacter + "'", closingCharacter);
                        }

                        var variable = expression.SubstringUpTo(index, closingCharacter);

                        CheckForUnrecognised(unrecognised, tokens, index);
                        tokens.Add(new Token(variable, index));
                        lengthProcessed = variable.Length;
                    }
                    else if (char.IsDigit(character))
                    {
                        var number = GetNumber(expression, index);

                        CheckForUnrecognised(unrecognised, tokens, index);
                        tokens.Add(new Token(number, index));
                        lengthProcessed = number.Length;
                    }
                    else if (IsQuote(character))
                    {
                        if (!CanGetString(expression, index, character))
                        {
                            throw new MissingTokenException("Missing closing token '" + character + "'", character);
                        }

                        var text = GetString(expression, index, character);

                        CheckForUnrecognised(unrecognised, tokens, index);
                        tokens.Add(new Token(text, index));
                        lengthProcessed = text.Length;
                    }
                    else if (character == DateSeparator)
                    {
                        if (!CanGetString(expression, index, character))
                        {
                            throw new MissingTokenException("Missing closing token '" + character + "'", character);
                        }

                        // Ignore the first # when checking to allow us to find the second.
                        var dateString = "#" + expression.SubstringUpTo(index + 1, DateSeparator);

                        CheckForUnrecognised(unrecognised, tokens, index);
                        tokens.Add(new Token(dateString, index));
                        lengthProcessed = dateString.Length;
                    }
                    else if (character == ParameterSeparator)
                    {
                        CheckForUnrecognised(unrecognised, tokens, index);
                        tokens.Add(new Token(character.ToString(), index));
                        lengthProcessed = 1;
                    }
                    else if ((character == 't' || character == 'T') && CanExtractValue(expression, expressionLength, index, "true"))
                    {
                        CheckForUnrecognised(unrecognised, tokens, index);
                        var trueString = ExtractValue(expression, expressionLength, index, "true");

                        if (!StringUtils.IsNullOrWhiteSpace(trueString))
                        {
                            tokens.Add(new Token(trueString, index));
                            lengthProcessed = 4;
                        }
                    }
                    else if ((character == 'f' || character == 'F') && CanExtractValue(expression, expressionLength, index, "false"))
                    {
                        CheckForUnrecognised(unrecognised, tokens, index);
                        var falseString = ExtractValue(expression, expressionLength, index, "false");

                        if (!StringUtils.IsNullOrWhiteSpace(falseString))
                        {
                            tokens.Add(new Token(falseString, index));
                            lengthProcessed = 5;
                        }
                    }
                    else if (character == 'n' && CanExtractValue(expression, expressionLength, index, "null")) // Check for null
                    {
                        CheckForUnrecognised(unrecognised, tokens, index);
                        var nullString = ExtractValue(expression, expressionLength, index, "null");

                        if (!StringUtils.IsNullOrWhiteSpace(nullString))
                        {
                            tokens.Add(new Token(nullString, index));
                            lengthProcessed = 4;
                        }
                    }
                    else if (!char.IsWhiteSpace(character))
                    {
                        // If we don't recognise this item then we had better keep going until we find something we know about.
                        if (unrecognised == null)
                        {
                            unrecognised = new List<char>();
                        }

                        foundUnrecognisedCharacter = true;
                        unrecognised.Add(character);
                    }
                }

                // Clear down the unrecognised buffer;
                if (!foundUnrecognisedCharacter)
                {
                    CheckForUnrecognised(unrecognised, tokens, index);
                    unrecognised = null;
                }
                index += (lengthProcessed == 0) ? 1 : lengthProcessed;
            }

            // Double check whether the last part is unrecognised.
            CheckForUnrecognised(unrecognised, tokens, index);

            return tokens;
        }

        private static void CheckForUnrecognised(IList<char> unrecognised, IList<Token> tokens, int index)
        {
            if (unrecognised != null)
            {
                string currentToken = new string(unrecognised.ToArray());
                tokens.Add(new Token(currentToken, index - currentToken.Length)); // The index supplied is the current location not the start of the unrecoginsed token.
            }
        }

        #endregion
    }
}
