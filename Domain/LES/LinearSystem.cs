using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.LES
{
    public class LinearSystem : ICloneable
    {
        private readonly List<Row> _rows;

        public LinearSystem(List<Row> rows)
        {
            _rows = rows;
        }

        public ResultVector Solution()
        {

            var result = this.Clone() as LinearSystem;

            for (var i = 0; ; i++)
            {
                var firstElement = _rows[i][i];
                var newRow = _rows[i].Multiply(1.0 / firstElement.Value);

                result = result?.ReplaceRow(i, newRow);
                
                if (i + 1 == _rows.Count) break;

                for (var j = i + 1; j < _rows.Count; j++)
                {
                    
                }
            }
        }

        public LinearSystem ReplaceRow(int index, Row row)
        {
            var result = _rows.Select(it => it.Clone() as Row).ToList();
            result[index] = row.Clone() as Row;
            return new LinearSystem(result);
        }


        public object Clone()
        {
            var rows = _rows.Select(it => it.Clone() as Row).ToList();
            return new LinearSystem(rows);
        }
    }
}