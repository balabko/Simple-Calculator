using System;
using SimpleCalculator.Core;
using SimpleCalculator.InputManagement;

namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public class ReadOperationStateExecutor : BaseStateExecutor, IStateExecutor
    {
        public ReadOperationStateExecutor(ISCInputManager scInputManager) : base(scInputManager,
            CalculatorStreamReaderState.ReadOperation)
        {
        }

        public IStateExecutorResult AddChar(char keyChar)
        {
            if (Char.IsDigit(keyChar))
            {
                AddDigitChar(keyChar);
                return new StateExecutorResult
                {
                    ConsoleResult = keyChar.ToString(),
                    NextState = CalculatorStreamReaderState.ReadDigit
                };
            }

            return new StateExecutorResult {ConsoleResult = String.Empty, NextState = CurrentState};
        }

        public IStateExecutorResult RemoveChar()
        {
            return new StateExecutorResult {ConsoleResult = String.Empty, NextState = CurrentState};
        }

        public IStateExecutorResult SetOperation(SCBinOperation operation, char operationKeyChar)
        {
            SetOperation(operation);
            return new StateExecutorResult {ConsoleResult = "\b" + operationKeyChar, NextState = CurrentState};
        }

        public IStateExecutorResult CalculateResult()
        {
            var resultErrorMessage = FinishNumber();
            if (resultErrorMessage != null)
            {
                return new StateExecutorResult
                {
                    ErrorMessage = resultErrorMessage
                };
            }

            return new StateExecutorResult
            {
                ConsoleResult = "0=" + GetResultAndReset() + "\n",
                NextState = CalculatorStreamReaderState.ReadDigit
            };
        }
    }
}
