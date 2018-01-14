namespace SimpleCalculator.Core
{
    public interface ISCProcessor<T>
    {
        T LopRes { get; set; }

        T Rop { get; set; }

        SCBinOperation Operation { get; set; }

        void Reset();

        void ResetOperation();

        void ExecuteOperation();
    }
}
