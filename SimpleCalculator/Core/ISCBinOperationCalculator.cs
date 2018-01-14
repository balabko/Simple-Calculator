namespace SimpleCalculator.Core
{
    public interface ISCBinOperationCalculator<T>
    {
        T Execute(T left, T right);
    }
}
