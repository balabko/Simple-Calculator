namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public interface IStateExecutorFactory
    {
        IStateExecutor GetStreamReaderStateExecutor(CalculatorStreamReaderState calculatorStreamReaderState);
    }
}
