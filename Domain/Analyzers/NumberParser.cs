using System.Text;
using System.Text.RegularExpressions;
using Domain.Elements;

namespace Domain.Analyzers
{
    public class NumberParser : IParser
    {

        public ElementWithLength GetNumber(string expression, int index)
        {
            var regex = new Regex("[0-9]|,");
            var strBuilderResult = new StringBuilder();

            while (regex.IsMatch(expression[index].ToString()))
            {
                strBuilderResult.Append(expression[index]);
                index++;
            }

            var strResult = strBuilderResult.ToString();

            return new ElementWithLength(new Number(float.Parse(strResult)), strResult.Length);
        }

        public bool Check(string expression, int index) =>
            new Regex("[0-9]").IsMatch(expression[index].ToString());
    }
}