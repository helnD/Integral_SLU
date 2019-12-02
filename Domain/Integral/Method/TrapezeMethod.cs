using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sprache.Calc;

namespace Domain.Integral.Method
{
    public class TrapezeMethod : IIntegralMethod
    {
        private readonly XtensibleCalculator _calculator = new XtensibleCalculator();

        public double Calculate(double start, double step, string expression)
        {
            var function = _calculator.ParseExpression(expression,
                X => start, Pi => Math.PI, E => Math.E).Compile();
            var foundation1 = Math.Abs(function());
            
            function = _calculator.ParseExpression(expression,
                X => start + step, Pi => Math.PI, E => Math.E).Compile();
            var foundation2 = Math.Abs(function());
            
            return (foundation1 + foundation2) / 2 * step;
        }
    }
}