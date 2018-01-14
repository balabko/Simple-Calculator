using SimpleCalculator.Core;

namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public interface IStateExecutor
    {
        IStateExecutorResult AddChar(char keyChar);

        IStateExecutorResult RemoveChar();

        IStateExecutorResult SetOperation(SCBinOperation operation, char operationKeyChar);

        IStateExecutorResult CalculateResult();
    }
}
