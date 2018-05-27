﻿using Expressive.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressive.Operators.Additive
{
    internal class SubtractOperator : OperatorBase
    {
        #region IOperator Members

        public override string[] Tags { get { return new[] { "-", "\u2212" }; } }

        public override IExpression BuildExpression(Token previousToken, IExpression[] expressions, ExpressiveOptions options)
        {
            if (IsUnary(previousToken))
            {
                return new UnaryExpression(UnaryExpressionType.Minus, expressions[0] ?? expressions[1]);
            }

            return new BinaryExpression(BinaryExpressionType.Subtract, expressions[0], expressions[1], options);
        }

        public override bool CanGetCaptiveTokens(Token previousToken, Token token, Queue<Token> remainingTokens)
        {
            var remainingTokensCopy = new Queue<Token>(remainingTokens.ToArray());

            return this.GetCaptiveTokens(previousToken, token, remainingTokensCopy).Any();
        }

        public override Token[] GetInnerCaptiveTokens(Token[] allCaptiveTokens)
        {
            return allCaptiveTokens.Skip(1).ToArray();
        }

        public override OperatorPrecedence GetPrecedence(Token previousToken)
        {
            if (IsUnary(previousToken))
            {
                return OperatorPrecedence.UnaryPlus;
            }
            return OperatorPrecedence.Add;
        }

        #endregion

        private bool IsUnary(Token previousToken)
        {
            return string.IsNullOrEmpty(previousToken.CurrentToken) ||
                string.Equals(previousToken.CurrentToken, "(", StringComparison.Ordinal) ||
                previousToken.CurrentToken.IsArithmeticOperator();
        }
    }
}
