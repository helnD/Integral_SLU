using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Elements;

namespace Domain.Analyzers
{
    public class FunctionParser : IParser
    {

        private string _function;
        
        private readonly HashSet<string> _functions = new HashSet<string>
        {
            "log", "sin", "cos", "tg", "ctg"
        };
        
        public bool Check(string expression, int index)
        {
            if (expression.Length - index < 4) return false;

            var word = new StringBuilder();
            var regex = new Regex("[a-z]");

            while (regex.IsMatch(expression[index].ToString()))
            {
                word.Append(expression[index]);
                index++;
            }

            if (word.Length == 0) return false;

            if (_functions.All(it => it != word.ToString())) return false;

            _function = word.ToString();
            return true;
        }

        public ElementWithLength GetFunction(string expression, int index)
        {
            int length = _function.Length + 1;
            int borderCount = 0;
            var parameters = new List<string>();
            var newParameter = new StringBuilder();

            index += length;

            while (borderCount == 0 && expression[index] != ')')
            {

                length++;
                
                if (expression[index] == '(') borderCount++;
                if (expression[index] == ')') borderCount--;

                if (expression[index] == ',' && borderCount == 0)
                {
                    parameters.Append(newParameter.ToString());
                    newParameter = new StringBuilder();
                    index++;
                    continue;
                }

                newParameter.Append(expression[index]);
                index++;

            }

            length++;
            
            return new ElementWithLength(new Function(_function, parameters), length);
        }
    }
}