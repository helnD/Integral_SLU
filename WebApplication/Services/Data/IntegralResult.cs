using Domain.Integral;

namespace WebApplication.Services.Data
{
    public class IntegralResult : Result
    {
        public IntegralResult(double value)
        {
            Value = value;
        }
        
        public double Value { get; }

    }
}