namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public interface IStateExecutorResult
    {
        CalculatorStreamReaderState NextState { get; set; }

        string ConsoleResult { get; set; }

        string ErrorMessage { get; set; }
    }
}
