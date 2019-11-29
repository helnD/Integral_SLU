using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.LES
{
    public class Row : ICloneable
    {
        private List<Element> _elements;

        public Row(List<Element> elements)
        {
            _elements = elements;
        }

        public int Count => _elements.Count;

        public Row Plus(Row row)
        {
            var elements = new List<Element>();

            for (int index = 0; index < _elements.Count; index++)
            {
                elements.Add(new Element(index,
                    row[index].Value + this[index].Value));
            }
            
            return new Row(elements);
        }
        
        public Row Multiply(double number)
        {
            var elements = new List<Element>();

            for (int index = 0; index < _elements.Count; index++)
            {
                elements.Add(new Element(index, this[index].Value * number));
            }
            
            return new Row(elements);
        }

        public Element this[int index] =>
            _elements[index];

        public object Clone()
        {
            var elements = _elements.Select(it => new Element(it.Number, it.Value));
            return new Row(elements.ToList());
        }
    }
}