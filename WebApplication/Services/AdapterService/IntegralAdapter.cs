using System;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Integral.Method;
using Microsoft.AspNetCore.Http;
using WebApplication.Services.Data;

namespace WebApplication.Services.AdapterService
{
    public class IntegralAdapter : IAdapterService
    {
        public Adapted Adapt(IQueryCollection collection)
        {
            var bottom = Convert.ToDouble(collection["sub"]
                .ToString()
                .Replace('.', ','));
            
            var top = Convert.ToDouble(collection["sup"]
                .ToString()
                .Replace('.', ','));
            
            var numberOfElements = Convert.ToDouble(collection["range"]
                .ToString()
                .Replace('.', ','));
            
            var expression = new StringBuilder(collection["func"]
                .ToString()
                .ToLower());

            var prevIsNotChar = true;
            var charRegex = new Regex("[a-z]|[A-Z]");
            for (var i = 0; i < expression.Length; i++)
            {
                if (charRegex.IsMatch(expression[i].ToString()))
                {
                    if (prevIsNotChar)
                    {
                        expression[i] = expression[i].ToString().ToUpper()[0];
                        prevIsNotChar = false;
                    }
                }
                else
                {
                    prevIsNotChar = true;
                }
            }

            var strMethod = collection["meth"].ToString();
            IIntegralMethod method;

            switch (strMethod)
            {
                case "method1":
                    method = new RectangleMethod();
                    break;
                default:
                    method = new TrapezeMethod();
                    break;
            }
            
            return new IntegralParameter(expression.ToString(), bottom, top, numberOfElements, method);
        }
    }
}