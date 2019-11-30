using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            var stepMatrix = StepMatrix(_rows);
            var solutions = new List<Element>();
            
            for (var i = stepMatrix.Count - 1; i >= 0; i--)
            {
                var subtrahend = 0.0;
                for (var j = i + 1; j < stepMatrix.Count; j++)
                {
                    subtrahend += stepMatrix[i][j].Value * solutions.Single(it => it.Number == j).Value;
                }

                var solution = (stepMatrix[i][stepMatrix.Count].Value - subtrahend);
                
                solutions.Add(new Element(i, solution));
            }
            
            return new ResultVector(solutions);
        }

        public LinearSystem ReplaceRow(int index, Row row)
        {
            var result = _rows.Select(it => it.Clone() as Row).ToList();
            result[index] = row.Clone() as Row;
            return new LinearSystem(result);
        }

        public Element this[int index1, int index2] =>
            _rows[index1][index2];
        
        public Row this[int index1] =>
            _rows[index1];

        public int Count => _rows.Count;

        public object Clone()
        {
            var rows = _rows.Select(it => it.Clone() as Row).ToList();
            return new LinearSystem(rows);
        }

        private LinearSystem StepMatrix(List<Row> rows)
        {
            var result = this.Clone() as LinearSystem;

            for (var i = 0; ; i++)
            {
                var firstElement = result[i][i];
                var newRow = result[i].Multiply(1.0 / firstElement.Value);

                result = result?.ReplaceRow(i, newRow);
                
                if (i + 1 == result.Count) break;

                for (var j = i + 1; j < result.Count; j++)
                {
                    var multiplier = result[j][i].Value > 0 ? -1 : 1;

                    newRow = result[i].Multiply(multiplier * Math.Abs(result[j][i].Value))
                        .Plus(result[j]);
                    result = result?.ReplaceRow(j, newRow);
                }
            }

            return result;
        }
    }
}