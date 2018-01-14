using System;
using SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor;
using SimpleCalculator.Core;

namespace SimpleCalculator.App.CalculatorStreamReader
{
    public class CalculatorStreamReader : ICalculatorStreamReader
    {
        private readonly IStateExecutorFactory _stateExecutorFactory;
        private CalculatorStreamReaderState _calculatorStreamReaderState = CalculatorStreamReaderState.ReadDigit;

        public CalculatorStreamReader(IStateExecutorFactory stateExecutorFactory)
        {
            _stateExecutorFactory = stateExecutorFactory;
        }

        public string ReadKey(ConsoleKeyInfo key)
        {
            var stateExecutor =
                _stateExecutorFactory.GetStreamReaderStateExecutor(_calculatorStreamReaderState);
            
            var consoleKey = key.Key;
            var keyChar = key.KeyChar;

            IStateExecutorResult stateExecutorResult;
            switch (consoleKey)
            {
                case ConsoleKey.Backspace:
                    stateExecutorResult = stateExecutor.RemoveChar();
                    break;

                case ConsoleKey.Enter:
                    stateExecutorResult = stateExecutor.CalculateResult();
                    break;

                case ConsoleKey.Add:
                case ConsoleKey.OemPlus:
                    stateExecutorResult = keyChar == '='
                        ? stateExecutor.CalculateResult()
                        : stateExecutor.SetOperation(SCBinOperation.Add, keyChar);
                    break;

                case ConsoleKey.Subtract:
                case ConsoleKey.OemMinus:
                    stateExecutorResult = stateExecutor.SetOperation(SCBinOperation.Subtract, keyChar);
                    break;

                default:
                    stateExecutorResult = stateExecutor.AddChar(keyChar);
                    break;
            }

            if (stateExecutorResult.ErrorMessage != null)
            {
                Reset();
                return $"\n\nОшибка! {stateExecutorResult.ErrorMessage}\n\n";
            }

            _calculatorStreamReaderState = stateExecutorResult.NextState;
            return stateExecutorResult.ConsoleResult;
        }

        private void Reset()
        {
            _calculatorStreamReaderState = CalculatorStreamReaderState.ReadDigit;
        }
    }
}
