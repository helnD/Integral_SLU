using System.Collections.Generic;

namespace Domain.Elements
{
    public class Function : Element
    {
        public Function(string name, List<Parameter> parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        public string Name { get; }
        public List<Parameter> Parameters { get; }
    }
}