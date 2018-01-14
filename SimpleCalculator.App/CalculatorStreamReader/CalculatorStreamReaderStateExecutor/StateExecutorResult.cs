namespace SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor
{
    public class StateExecutorResult : IStateExecutorResult
    {
        public CalculatorStreamReaderState NextState { get; set; }

        public string ConsoleResult { get; set; }

        public string ErrorMessage { get; set; }
    }
}
