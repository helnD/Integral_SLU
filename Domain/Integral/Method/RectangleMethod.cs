using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Sprache.Calc;

namespace Domain.Integral.Method
{
    public class RectangleMethod : IIntegralMethod
    {
        
        
        public double Calculate(Integral integral)
        {

            var watch = new Stopwatch();
            watch.Start();
            
            var sum = 0.0;
            var step = (integral.TopLimit - integral.BottomLimit) / integral.Difference;

            var xx = integral.BottomLimit;

            for (var x = integral.BottomLimit; x < integral.TopLimit - step; x += 3 * step)
            {
                var firstCalc = new ColumnCalculator(x, step, integral.Expression);
                var secondCalc = new ColumnCalculator(x + step, step, integral.Expression);
                var thirdCalc = new ColumnCalculator(x + step * 2, step, integral.Expression);
          
                firstCalc.Run();
                secondCalc.Run();
                thirdCalc.Run();
                
                firstCalc.JoinThread();
                secondCalc.JoinThread();
                thirdCalc.JoinThread();
                
                sum += firstCalc.Result + secondCalc.Result + thirdCalc.Result;
            }
            
            watch.Stop();
            
            Console.WriteLine($"Время: {watch.ElapsedMilliseconds}");

            return sum;
        }

    }
}