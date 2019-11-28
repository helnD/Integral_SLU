using System;
using System.Threading;
using Sprache.Calc;

namespace Domain.Integral
{
    public class ColumnCalculator
    {
        private readonly double _start;
        private readonly double _step;
        private readonly string _expression;
        private readonly XtensibleCalculator _calculator = new XtensibleCalculator();
        private Thread _thread;

        public ColumnCalculator(double start, double step, string expression)
        {
            _start = start;
            _step = step;
            _expression = expression;
        }
        
        public double Result { private set; get; }

        public void Run()
        {
            _thread = new Thread(new ThreadStart(Calculate));
            _thread.Start();
        }

        private void Calculate()
        {
            var function = _calculator.ParseExpression(_expression,
                x => _start, pi => Math.PI, e => Math.E);
            
            var height = function.Compile()();
            Result = height * _step;
        }

        public void JoinThread()
        {
            _thread.Join();
        }
    }
}