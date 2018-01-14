using System;
using SimpleCalculator.Core;
using SimpleCalculator.InputManagement;

namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public class ReadDigitStateExecutor : BaseStateExecutor, IStateExecutor
    {
        public ReadDigitStateExecutor(ISCInputManager scInputManager) : base(scInputManager,
            CalculatorStreamReaderState.ReadDigit)
        {
        }

        public IStateExecutorResult AddChar(char keyChar)
        {
            if (Char.IsDigit(keyChar))
            {
                AddDigitChar(keyChar);
                return new StateExecutorResult {ConsoleResult = keyChar.ToString(), NextState = CurrentState};
            }

            return new StateExecutorResult {ConsoleResult = String.Empty, NextState = CurrentState};
        }

        public IStateExecutorResult RemoveChar()
        {
            return RemoveLastDigit() == 0
                ? new StateExecutorResult {ConsoleResult = "\b \b", NextState = CurrentState}
                : new StateExecutorResult {ConsoleResult = String.Empty, NextState = CurrentState};
        }

        public IStateExecutorResult SetOperation(SCBinOperation operation, char operationKeyChar)
        {
            var resultErrorMessage = FinishNumber();
            if (resultErrorMessage != null)
            {
                return new StateExecutorResult
                {
                    ErrorMessage = resultErrorMessage
                };
            }

            SetOperation(operation);

            return new StateExecutorResult
            {
                ConsoleResult = operationKeyChar.ToString(),
                NextState = CalculatorStreamReaderState.ReadOperation
            };
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
                ConsoleResult = '=' + GetResultAndReset() + '\n',
                NextState = CalculatorStreamReaderState.ReadDigit
            };
        }
    }
}
