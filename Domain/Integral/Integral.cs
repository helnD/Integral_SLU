using System.Collections.Generic;
using System.Linq;
using Domain.Integral.Method;

namespace Domain.Integral
{
    public class Integral
    {
        public Integral(string expression, double bottomLimit, double topLimit, double numberOfElements)
        {
            Expression = expression;
            BottomLimit = bottomLimit;
            TopLimit = topLimit;
            NumberOfElements = numberOfElements;
        }

        public string Expression { get; }
        public double BottomLimit { get; }
        public double TopLimit { get; }
        public double NumberOfElements { get; }

        public double Calculate(IIntegralMethod method)
        {
            var sum = 0.0;
            var step = (TopLimit - BottomLimit) / NumberOfElements;

            var x = BottomLimit;

            while (x < TopLimit)
            {
                var threads = new List<ColumnCalculator>();
                var count = 0;

                while (count < 3 && x < TopLimit)
                {

                    if (x + step > TopLimit)
                    {
                        step = TopLimit - x;
                    }
                    
                    var calcThread = new ColumnCalculator(x, step, Expression, method);
                    threads.Add(calcThread);
                    count++;
                    x += step;
                }
                
                threads.ForEach(it => it.Run());
                threads.ForEach(it => it.JoinThread());

                sum += threads.Sum(it => it.Result);
            }

            return sum;
        }
    }
}