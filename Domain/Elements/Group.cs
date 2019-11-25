using System.Collections.Generic;

namespace Domain.Elements
{
    public class Group
    {
        public Group(List<Element> elements, int priority)
        {
            Elements = elements;
            Priority = priority;
        }

        public List<Element> Elements { get; }
        public int Priority { get; }
    }
}