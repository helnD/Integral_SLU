using System;
using System.Collections.Generic;
using Domain.Elements;

namespace Domain
{
    public class Substitute
    {
        public List<Element> Replace(List<Element> elements, List<Element> removableElements,
            Element newElement)
        {
            throw new NotImplementedException();
        }

        public string ReplaceSymbols(Dictionary<char, float> arguments)
        {
            throw new NotImplementedException();
        }
    }
}