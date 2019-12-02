using System;
using System.Collections.Generic;
using System.Linq;
using Domain.LES;
using Microsoft.AspNetCore.Http;
using WebApplication.Services.Data;

namespace WebApplication.Services.AdapterService
{
    public class LesAdapter : IAdapterService
    {
        public Adapted Adapt(IQueryCollection collection)
        {
            var length = Convert.ToInt16(collection["length"]
                .ToString()
                .Replace('.', ','));

            var rows = new List<Row>();
            var coefficients = collection
                .Where(it => it.Key.First() == 'a')
                .ToList();

            for (var i = 0; i < length; i++)
            {
                var row = new List<Element>();
                for (var j = 0; j < coefficients.ToList().Count / length; j++)
                {
                    var element = new Element(j, Convert.ToDouble(coefficients[j + length * i].Value));
                    row.Add(element);
                }
                row.Add(new Element(i, Convert.ToDouble(collection["b" + (i + 1)])));
                rows.Add(new Row(row));
            }
            
            return new LesParameter(rows);
        }
    }
}