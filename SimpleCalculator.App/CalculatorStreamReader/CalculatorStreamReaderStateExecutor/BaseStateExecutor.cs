using System;
using SimpleCalculator.Core;
using SimpleCalculator.InputManagement;

namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public abstract class BaseStateExecutor
    {
        private readonly ISCInputManager _scInputManager;
        protected readonly CalculatorStreamReaderState CurrentState;

        protected BaseStateExecutor(ISCInputManager scInputManager, CalculatorStreamReaderState currentState)
        {
            _scInputManager = scInputManager;
            CurrentState = currentState;
        }

        protected int AddDigitChar(char keyChar)
        {
            _scInputManager.AddDigitChar(keyChar);
            return 0;
        }

        protected int RemoveLastDigit()
        {
            if (_scInputManager.GetNumberLength() > 0)
            {
                _scInputManager.RemoveLastDigit();
                return 0;
            }

            return 1;
        }

        protected int SetOperation(SCBinOperation operation)
        {
            _scInputManager.SetOperation(operation);
            return 0;
        }

        protected string FinishNumber()
        {
            if (_scInputManager.FinishNumber() == 1)
            {
                var errorMessage = _scInputManager.Error?.Message ?? String.Empty;
                _scInputManager.Reset();
                return errorMessage;
            }

            return null;
        }

        protected string GetResultAndReset()
        {
            string result = _scInputManager.GetResult();
            _scInputManager.Reset();
            return result;
        }
    }
}
