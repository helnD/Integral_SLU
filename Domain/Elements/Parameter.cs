using System.Collections.Generic;

namespace Domain.Elements
{
    public class Parameter : Element
    {
        public Parameter(List<Element> elements)
        {
            Elements = elements;
        }

        public List<Element> Elements { get; }
    }
}