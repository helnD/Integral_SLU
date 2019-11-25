using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            index += _function.Length;
            index++;

            var parameters = new List<StringBuilder>();

            int borderCount = 0;
            int commaCount = 0;

            while (expression[index] != ')' && borderCount == 0)
            {

                var newParameter = new StringBuilder();
                
                while (expression[index] != ',' && commaCount == 0)
                {
                    if (expression[index] == ')' || borderCount == 0) break;
                    
                    
                }
            }

        }
    }
}