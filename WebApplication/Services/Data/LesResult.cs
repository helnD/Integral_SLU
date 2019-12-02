using System.Collections.Generic;

namespace WebApplication.Services.Data
{
    public class LesResult : Result
    {
        public LesResult(List<double> result)
        {
            Result = result;
        }

        public List<double> Result { get; }
    }
}