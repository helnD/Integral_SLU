using System.Collections.Generic;
using System.Linq;
using Domain.Elements;

namespace Domain.Analyzers
{

    public class ThirdStageOperatorParser : IParser
    {

        private string _foundOperator;
        
        private readonly HashSet<string> _thirdStage = new HashSet<string>
        {
            "+", "-"
        };
        
        public bool Check(string expression, int index)
        {
            _foundOperator = _thirdStage.First(it => it == expression[index].ToString());
            return _foundOperator != null;
        }
        

        public ElementWithLength GetThirdStageOperator(int id)
        {
            return new ElementWithLength(new FirstStageOperator(id, _foundOperator), _foundOperator.Length);
        }
    }
}