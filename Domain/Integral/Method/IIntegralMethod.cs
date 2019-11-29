using System;

namespace Domain.Integral.Method
{
    public interface IIntegralMethod
    {
        double Calculate(double start, double step, string expression);
    }
}