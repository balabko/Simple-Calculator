namespace SimpleCalculator.Core
{
    public sealed class SCProcessor<T> : ISCProcessor<T> where T: new()
    {
        private readonly ISCBinOperationFactory<T> _operationFactory;

        public T LopRes { get; set; }

        public T Rop { get; set; }

        public SCBinOperation Operation { get; set; }

        public SCProcessor(ISCBinOperationFactory<T> operationFactory)
        {
            _operationFactory = operationFactory;
            Reset();
        }

        public void Reset()
        {
            LopRes = new T();
            Rop = new T();

            ResetOperation();
        }

        public void ResetOperation()
        {
            Operation = SCBinOperation.None;
        }

        public void ExecuteOperation()
        {
            if (Operation != SCBinOperation.None)
            {
                 LopRes = _operationFactory.GetBinOperationCalculator(Operation).Execute(LopRes, Rop);       
            }
        }
    }
}
