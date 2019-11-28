using System;
using System.Diagnostics;
using Sprache.Calc;

namespace Domain.Integral.Method
{
    public class TrapezeMethod : IIntegralMethod
    {
        private readonly XtensibleCalculator _calculator = new XtensibleCalculator();

        public double Calculate(Integral integral)
        {
            var sum = 0.0;
            var step = (integral.TopLimit - integral.BottomLimit) / integral.Difference;
            
            var watch = new Stopwatch();
            watch.Start();

            for (var xState = integral.BottomLimit; xState < integral.TopLimit; xState += step)
            {
                var state = xState;
                var function = _calculator.ParseExpression(integral.Expression, x => state, pi => Math.PI, e => Math.E);
                var height1 = function.Compile()();
                
//                function = _calculator.ParseExpression(integral.Expression, x => state + step, pi => Math.PI, e => Math.E);
//                var height2 = function.Compile()();

                sum += height1 * step;
            }
            
            watch.Stop();
            
            Console.WriteLine($"Время: {watch.ElapsedMilliseconds}");

            return sum;
        }
    }
}