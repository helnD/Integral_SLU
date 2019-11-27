using System.Collections.Generic;

namespace Domain.Elements
{
    public class Function : Element, IContainer
    {
        public Function(string name, List<string> parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        public string Name { get; }
        public List<string> Parameters { get; }
    }
}