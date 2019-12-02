using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Sprache.Calc;

namespace Domain.Integral.Method
{
    public class RectangleMethod : IIntegralMethod
    {
        private readonly XtensibleCalculator _calculator = new XtensibleCalculator();

        public double Calculate(double start, double step, string expression)
        {
            var function = _calculator.ParseExpression(expression,
                X => start, Pi => Math.PI, E => Math.E).Compile();

            return function() * step;
        }
    }
}