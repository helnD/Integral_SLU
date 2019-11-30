using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.LES
{
    public class ResultVector : ICloneable
    {

        private readonly List<Element> _results;
        
        public List<Element> Results => (Clone() as ResultVector)?._results;
        
        public ResultVector(List<Element> results)
        {
            results.Sort((x, y) => x.Number.CompareTo(y.Number));
            _results = results;
        }

        public object Clone()
        {
            var results = _results.Select(it => new Element(it.Number, it.Value)).ToList();
            return new ResultVector(results);
        }
    }
}