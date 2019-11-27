using System.Text;
using Domain.Elements;

namespace Domain.Analyzers
{
    public class GroupParser : IParser
    {
        public bool Check(string expression, int index) =>
            expression[index] == ')';

        public ElementWithLength GetGroup(string expression, int index, int priority)
        {
            var borderCount = 0;
            var container = new StringBuilder();

            while (expression[index] != ')' && borderCount == 0)
            {
                if (expression[index] == '(') borderCount++;
                if (expression[index] == ')') borderCount--;

                container.Append(expression[index]);
                index++;
            }
            
            return new ElementWithLength(new Group(container.ToString(), priority),
                container.Length + 2);
        }
    }
}