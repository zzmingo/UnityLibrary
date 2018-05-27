﻿using Expressive.Expressions;
using System;

namespace Expressive.Functions.String
{
    internal class EndsWithFunction : FunctionBase
    {
        #region FunctionBase Members

        public override string Name
        {
            get
            {
                return "EndsWith";
            }
        }

        public override object Evaluate(IExpression[] parameters, ExpressiveOptions options)
        {
            this.ValidateParameterCount(parameters, 2, 2);

            string text = (string)parameters[0].Evaluate(Variables);
            string value = (string)parameters[1].Evaluate(Variables);

            if (value == null)
            {
                return false;
            }
            
            return text.EndsWith(value, options.HasFlag(ExpressiveOptions.IgnoreCase) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) == true;
        }

        #endregion
    }
}
