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
                x => start, pi => Math.PI, e => Math.E).Compile();
            var foundation1 = function();
            
            function = _calculator.ParseExpression(expression,
                x => start + step, pi => Math.PI, e => Math.E).Compile();
            var foundation2 = function();
            
            return (foundation1 + foundation2) / 2 * step;
        }
    }
}