using System;using SimpleCalculator.InputManagement;

namespace SimpleCalculator.ULongCalculator
{
    public class ULongSCStringConverter : ISCStringConverter<ulong>
    {
        public string ToString(ulong value)
        {
            return value.ToString();
        }

        public ulong FromString(string value)
        {
            if (value == string.Empty)
            {
                return 0;
            }

            var success = ulong.TryParse(value, out var result);

            if (!success)
            {
                throw new FormatException($"Не удаётся преобразовать значение {value} в тип ulong");
            }

            return result;
        }
    }
}
