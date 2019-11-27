using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Elements;

namespace Domain.Analyzers
{
    public class ExpressionAnalyzer
    {

        private readonly string _expression;
        
        private readonly FirstStageOperatorParser _firstStageOperator 
            = new FirstStageOperatorParser();
        private readonly SecondStageOperatorParser _secondStageOperator 
            = new SecondStageOperatorParser();
        private readonly ThirdStageOperatorParser _thirdStageOperator 
            = new ThirdStageOperatorParser();
        
        private readonly NumberParser _numberParser = new NumberParser();
        
        private readonly FunctionParser _functionParser = new FunctionParser();
        private readonly GroupParser _groupParser = new GroupParser();
        
        public ExpressionAnalyzer(string expression)
        {
            _expression = expression;
        }

        public List<Element> Analyze()
        {
            int priority = 0;
            int id = 0;

            var result = new List<Element>();

            for (int index = 0; index < _expression.Length; index++)
            {
                if (_numberParser.Check(_expression, index))
                {
                    var number = _numberParser.GetNumber(_expression, index);
                    result.Add(number.Element);
                    index += number.Length;
                }

                if (_firstStageOperator.Check(_expression, index))
                {
                    var operat = _firstStageOperator.GetFirstStageOperator(id);
                    result.Add(operat.Element);
                    index += operat.Length;
                }
                
                if (_secondStageOperator.Check(_expression, index))
                {
                    var operat = _secondStageOperator.GetSecondStageOperator(id);
                    result.Add(operat.Element);
                    index += operat.Length;
                }
                
                if (_thirdStageOperator.Check(_expression, index))
                {
                    var operat = _thirdStageOperator.GetThirdStageOperator(id);
                    result.Add(operat.Element);
                    index += operat.Length;
                }
                
                
                
            }
        }
    }
}