using System;
using System.Linq;
using Domain.Integral;
using Domain.LES;
using WebApplication.Services.Data;

namespace WebApplication.Services.IntegralService
{
    public class LesBuilderService : IBuilderService
    {
        public Result Build(Adapted lesParameter)
        {
            var parameter = lesParameter as LesParameter;
            if (lesParameter == null) throw new Exception("Параметер не содержит информации о системе уравнений");

            var result = new LinearSystem(parameter.Rows)
                .Solution()
                .Results.Select(it => Math.Round(it.Value, 2))
                .ToList();
            
            return new LesResult(result);
        }
    }
}