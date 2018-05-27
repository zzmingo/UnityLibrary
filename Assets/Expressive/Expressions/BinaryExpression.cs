﻿using Expressive.Exceptions;
using Expressive.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Expressive.Expressions
{
    internal class BinaryExpression : IExpression
    {
        private readonly BinaryExpressionType _expressionType;
        private readonly IExpression _leftHandSide;
        private readonly ExpressiveOptions _options;
        private readonly IExpression _rightHandSide;
        
        internal BinaryExpression(BinaryExpressionType type, IExpression lhs, IExpression rhs, ExpressiveOptions options)
        {
            _expressionType = type;
            _leftHandSide = lhs;
            _options = options;
            _rightHandSide = rhs;
        }

        #region IExpression Members

        public object Evaluate(IDictionary<string, object> variables)
        {
            if (_leftHandSide == null)
            {
                throw new MissingParticipantException("The left hand side of the operation is missing.");
            }
            else if (_rightHandSide == null)
            {
                throw new MissingParticipantException("The right hand side of the operation is missing.");
            }

            // We will evaluate the left hand side but hold off on the right hand side as it may not be necessary
            var lhsResult = _leftHandSide.Evaluate(variables);

            var ignoreCase = _options.HasFlag(ExpressiveOptions.IgnoreCase);

            switch (_expressionType)
            {
                case BinaryExpressionType.Unknown:
                    break;
                case BinaryExpressionType.And:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToBoolean(l) && Convert.ToBoolean(r));
                case BinaryExpressionType.Or:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToBoolean(l) || Convert.ToBoolean(r));
                case BinaryExpressionType.NotEqual:
                    {
                        object rhsResult = null;

                        // Use the type of the left operand to make the comparison
                        if (lhsResult == null)
                        {
                            rhsResult = _rightHandSide.Evaluate(variables);
                            if (rhsResult != null)
                            {
                                // 2 nulls make a match!
                                return true;
                            }

                            return false;
                        }
                        else
                        {
                            rhsResult = _rightHandSide.Evaluate(variables);

                            // If we got here then the lhsResult is not null.
                            if (rhsResult == null)
                            {
                                return true;
                            }
                        }

                        return Comparison.CompareUsingMostPreciseType(lhsResult, rhsResult, ignoreCase) != 0;
                    }
                case BinaryExpressionType.LessThanOrEqual:
                    {
                        // Use the type of the left operand to make the comparison
                        if (lhsResult == null)
                        {
                            return null;
                        }

                        var rhsResult = _rightHandSide.Evaluate(variables);
                        if (rhsResult == null)
                        {
                            return null;
                        }

                        return Comparison.CompareUsingMostPreciseType(lhsResult, rhsResult, ignoreCase) <= 0;
                    }
                case BinaryExpressionType.GreaterThanOrEqual:
                    {
                        // Use the type of the left operand to make the comparison
                        if (lhsResult == null)
                        {
                            return null;
                        }

                        var rhsResult = _rightHandSide.Evaluate(variables);
                        if (rhsResult == null)
                        {
                            return null;
                        }

                        return Comparison.CompareUsingMostPreciseType(lhsResult, rhsResult, ignoreCase) >= 0;
                    }
                case BinaryExpressionType.LessThan:
                    {
                        // Use the type of the left operand to make the comparison
                        if (lhsResult == null)
                        {
                            return null;
                        }

                        var rhsResult = _rightHandSide.Evaluate(variables);
                        if (rhsResult == null)
                        {
                            return null;
                        }

                        return Comparison.CompareUsingMostPreciseType(lhsResult, rhsResult, ignoreCase) < 0;
                    }
                case BinaryExpressionType.GreaterThan:
                    {
                        // Use the type of the left operand to make the comparison
                        if (lhsResult == null)
                        {
                            return null;
                        }

                        var rhsResult = _rightHandSide.Evaluate(variables);
                        if (rhsResult == null)
                        {
                            return null;
                        }

                        return Comparison.CompareUsingMostPreciseType(lhsResult, rhsResult, ignoreCase) > 0;
                    }
                case BinaryExpressionType.Equal:
                    {
                        object rhsResult = null;

                        // Use the type of the left operand to make the comparison
                        if (lhsResult == null)
                        {
                            rhsResult = _rightHandSide.Evaluate(variables);
                            if (rhsResult == null)
                            {
                                // 2 nulls make a match!
                                return true;
                            }

                            return false;
                        }
                        else
                        {
                            rhsResult = _rightHandSide.Evaluate(variables);

                            // If we got here then the lhsResult is not null.
                            if (rhsResult == null)
                            {
                                return false;
                            }
                        }

                        return Comparison.CompareUsingMostPreciseType(lhsResult, rhsResult, ignoreCase) == 0;
                    }
                case BinaryExpressionType.Subtract:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Numbers.Subtract(l, r));
                case BinaryExpressionType.Add:
                    if (lhsResult is string)
                    {
                        return ((string)lhsResult) + _rightHandSide.Evaluate(variables) as string;
                    }

                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Numbers.Add(l, r));
                case BinaryExpressionType.Modulus:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Numbers.Modulus(l, r));
                case BinaryExpressionType.Divide:
                    {
                        var rhsResult = _rightHandSide.Evaluate(variables);

                        return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) =>
                        {
                            return (l == null || r == null || IsReal(l) || IsReal(r))
                                     ? Numbers.Divide(l, r)
                                     : Numbers.Divide(Convert.ToDouble(l), r);
                        });
                    }
                case BinaryExpressionType.Multiply:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Numbers.Multiply(l, r));
                case BinaryExpressionType.BitwiseOr:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToUInt16(l) | Convert.ToUInt16(r));
                case BinaryExpressionType.BitwiseAnd:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToUInt16(l) & Convert.ToUInt16(r));
                case BinaryExpressionType.BitwiseXOr:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToUInt16(l) ^ Convert.ToUInt16(r));
                case BinaryExpressionType.LeftShift:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToUInt16(l) << Convert.ToUInt16(r));
                case BinaryExpressionType.RightShift:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => Convert.ToUInt16(l) >> Convert.ToUInt16(r));
                case BinaryExpressionType.NullCoalescing:
                    return this.Evaluate(lhsResult, _rightHandSide, variables, (l, r) => l ?? r);
                default:
                    break;
            }

            return null;
        }

        #endregion

        private static bool IsReal(object value)
        {
            var typeCode = Type.GetTypeCode(value.GetType());

            return typeCode == TypeCode.Decimal || typeCode == TypeCode.Double || typeCode == TypeCode.Single;
        }

        private object Evaluate(object lhsResult, IExpression rhs, IDictionary<string, object> variables, Func<object, object, object> resultSelector)
        {
            IList<object> lhsParticipants = new List<object>();
            IList<object> rhsParticipants = new List<object>();
            object rhsResult = rhs.Evaluate(variables);

            if (!(lhsResult is ICollection) && !(rhsResult is ICollection))
            {
                return resultSelector(lhsResult, rhsResult);
            }

            if (lhsResult is ICollection)
            {
                foreach (var item in ((ICollection)lhsResult))
                {
                    lhsParticipants.Add(item);
                }
            }
            if (rhsResult is ICollection)
            {
                foreach (var item in ((ICollection)rhsResult))
                {
                    rhsParticipants.Add(item);
                }
            }

            object[] result = null;

            if (lhsParticipants.Count == rhsParticipants.Count)
            {
                IList<object> resultList = new List<object>();

                for (int i = 0; i < lhsParticipants.Count; i++)
                {
                    resultList.Add(resultSelector(lhsParticipants[i], rhsParticipants[i]));
                }

                result = resultList.ToArray();
            }
            else if (lhsParticipants.Count == 0)
            {
                IList<object> resultList = new List<object>();

                for (int i = 0; i < rhsParticipants.Count; i++)
                {
                    resultList.Add(resultSelector(lhsResult, rhsParticipants[i]));
                }

                result = resultList.ToArray();
            }
            else if (rhsParticipants.Count == 0)
            {
                IList<object> resultList = new List<object>();

                for (int i = 0; i < lhsParticipants.Count; i++)
                {
                    resultList.Add(resultSelector(lhsParticipants[i], rhsResult));
                }

                result = resultList.ToArray();
            }

            return result;
        }
    }

    internal enum BinaryExpressionType
    {
        Unknown,
        And,
        Or,
        NotEqual,
        LessThanOrEqual,
        GreaterThanOrEqual,
        LessThan,
        GreaterThan,
        Equal,
        Subtract,
        Add,
        Modulus,
        Divide,
        Multiply,
        BitwiseOr,
        BitwiseAnd,
        BitwiseXOr,
        LeftShift,
        RightShift,
        NullCoalescing,
    }
}
