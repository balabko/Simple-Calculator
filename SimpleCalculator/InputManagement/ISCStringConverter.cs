namespace SimpleCalculator.InputManagement
{
    public interface ISCStringConverter<T>
    {
        string ToString(T value);

        T FromString(string value);
    }
}
