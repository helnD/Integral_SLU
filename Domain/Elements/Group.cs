using System.Collections.Generic;

namespace Domain.Elements
{
    public class Group : Element, IContainer
    {
        public Group(string elements, int priority)
        {
            Elements = elements;
            Priority = priority;
        }

        public string Elements { get; }
        public int Priority { get; }
    }
}