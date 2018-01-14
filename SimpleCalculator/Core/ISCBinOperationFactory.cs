namespace SimpleCalculator.Core
{
    public interface ISCBinOperationFactory<T>
    {
        ISCBinOperationCalculator<T> GetBinOperationCalculator(SCBinOperation operationType);
    }
}
