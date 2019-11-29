using System;
using System.Threading;
using Domain.Integral.Method;
using Sprache.Calc;

namespace Domain.Integral
{
    public class ColumnCalculator
    {
        private readonly double _start;
        private readonly double _step;
        private readonly string _expression;
        private readonly IIntegralMethod _method;
        private Thread _thread;

        public ColumnCalculator(double start, double step, string expression, IIntegralMethod method)
        {
            _start = start;
            _step = step;
            _expression = expression;
            _method = method;
        }
        
        public double Result { private set; get; }

        public void Run()
        {
            _thread = new Thread(Calculate);
            _thread.Start();
        }

        private void Calculate()
        {
            Result = _method.Calculate(_start, _step, _expression);
        }

        public void JoinThread()
        {
            _thread.Join();
        }
    }
}