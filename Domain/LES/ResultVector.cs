using System.Collections.Generic;

namespace Domain.LES
{
    public class ResultVector
    {
        private readonly List<double> _results;

        public ResultVector(List<double> results)
        {
            _results = results;
        }
    }
}