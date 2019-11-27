using System.Collections.Generic;
using System.Linq;
using Domain.Elements;

namespace Domain.Analyzers
{

    public class SecondStageOperatorParser : IParser
    {

        private string _foundOperator;
        
        private readonly HashSet<string> _secondStage = new HashSet<string>
        {
            "*", "/"
        };
        
        public bool Check(string expression, int index)
        {
            _foundOperator = _secondStage.First(it => it == expression[index].ToString());
            return _foundOperator != null;
        }
        

        public ElementWithLength GetSecondStageOperator(int id)
        {
            return new ElementWithLength(new FirstStageOperator(id, _foundOperator), _foundOperator.Length);
        }
    }
}