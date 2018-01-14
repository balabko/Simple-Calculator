using System;
using SimpleCalculator.InputManagement;

namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public class StateExecutorFactory : IStateExecutorFactory
    {
        private readonly ISCInputManager _scInputManager;

        public StateExecutorFactory(ISCInputManager scInputManager)
        {
            _scInputManager = scInputManager;
        }

        public IStateExecutor GetStreamReaderStateExecutor(CalculatorStreamReaderState calculatorStreamReaderState)
        {
            switch (calculatorStreamReaderState)
            {
                case CalculatorStreamReaderState.ReadDigit: return new ReadDigitStateExecutor(_scInputManager);
                case CalculatorStreamReaderState.ReadOperation: return new ReadOperationStateExecutor(_scInputManager);
                default: throw new NotSupportedException();
            }
        }
    }
}
