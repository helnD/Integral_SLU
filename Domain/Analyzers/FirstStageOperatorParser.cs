using System.Collections.Generic;
using System.Linq;
using Domain.Elements;

namespace Domain.Analyzers
{
    public class FirstStageOperatorParser : IParser
    {

        private string _foundOperator;
        
        private readonly HashSet<string> _firstStage = new HashSet<string>
        {
            "^"
        };
        
        public bool Check(string expression, int index)
        {
            _foundOperator = _firstStage.First(it => it == expression[index].ToString());
            return _foundOperator != null;
        }
        

        private ElementWithLength GetFirstStageOperator(int id)
        {
            return new ElementWithLength(new FirstStageOperator(id, _foundOperator), _foundOperator.Length);
        }
    }
}