using System.Collections.Generic;
using Domain.LES;

namespace WebApplication.Services.Data
{
    public class LesParameter : Adapted
    {
        public LesParameter(List<Row> rows)
        {
            Rows = rows;
        }
        
        public List<Row> Rows { get; }

    }
}