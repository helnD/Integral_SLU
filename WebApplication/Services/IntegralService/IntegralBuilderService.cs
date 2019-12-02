using System;
using Domain.Integral;
using Domain.Integral.Method;
using WebApplication.Services.Data;

namespace WebApplication.Services.IntegralService
{
    public class IntegralBuilderService : IBuilderService
    {
        public Result Build(Adapted lesParameter)
        {
            var parameter = lesParameter as IntegralParameter;
            if (lesParameter == null) throw new Exception("Параметер не содержит информации об интеграле");
            
            var integral = new Integral(parameter.Expression, parameter.BottomLimit, parameter.TopLimit,
                parameter.NumberOfElements);
            
            return new IntegralResult(Math.Round(integral.Calculate(parameter.Method), 3));
        }
    }
}