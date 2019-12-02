using Domain.Integral.Method;

namespace WebApplication.Services.Data
{
    public class IntegralParameter : Adapted
    {
        public IntegralParameter(string expression, double bottomLimit, double topLimit,
            double numberOfElements, IIntegralMethod method)
        {
            Expression = expression;
            BottomLimit = bottomLimit;
            TopLimit = topLimit;
            NumberOfElements = numberOfElements;
            Method = method;
        }

        public string Expression { get; }
        public double BottomLimit { get; }
        public double TopLimit { get; }
        public double NumberOfElements { get; }
        public IIntegralMethod Method { get; }
    }
}