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
                if (IsNumber(index))
                {
                    var number = GetNumber(index);
                    result.Add(number.Element);
                    index += number.Length - 1;
                    continue;
                }

                if (IsFirstStageOperator(index))
                {
                    var oper = GetFirstStageOperator(index, id);
                    result.Add(oper.Element);
                    index += oper.Length - 1;
                    id++;
                    continue;
                }

                if (IsSecondStageOperator(index))
                {
                    var oper = GetSecondStageOperator(index, id);
                    result.Add(oper.Element);
                    index += oper.Length - 1;
                    id++;
                    continue;
                }

                if (IsThirdStageOperator(index))
                {
                    var oper = GetThirdStageOperator(index, id);
                    result.Add(oper.Element);
                    index += oper.Length - 1;
                    id++;
                    continue;
                }


            }
        }
    }
}