using System;
using Domain.Integral;
using Domain.Integral.Method;
using WebApplication.Services.Data;

namespace WebApplication.Services.IntegralService
{
    public class SimpleBuilderService : IIntegralBuilderService
    {
        public double Build(Adapted integralParameter)
        {
            var parameter = integralParameter as IntegralParameter;
            if (integralParameter == null) throw new Exception("Параметер не содержит информации об интеграле");
            
            var integral = new Integral(parameter.Expression, parameter.BottomLimit, parameter.TopLimit,
                parameter.NumberOfElements);
            
            return Math.Round(integral.Calculate(parameter.Method), 3);
        }
    }
}