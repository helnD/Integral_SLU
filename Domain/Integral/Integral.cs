using Domain.Integral.Method;

namespace Domain.Integral
{
    public class Integral
    {
        public Integral(string expression, double bottomLimit, double topLimit, double difference)
        {
            Expression = expression;
            BottomLimit = bottomLimit;
            TopLimit = topLimit;
            Difference = difference;
        }

        public string Expression { get; }
        public double BottomLimit { get; }
        public double TopLimit { get; }
        public double Difference { get; }

        public double Calculate(IIntegralMethod method) =>
            method.Calculate(this);
    }
}