using System;
using SimpleCalculator.Core;

namespace SimpleCalculator.ULongCalculator
{
    public class SubtractULongCalculator : ISCBinOperationCalculator<ulong>
    {
        public ulong Execute(ulong left, ulong right)
        {
            if (left < right)
            {
                throw new OverflowException("Такая операция вычитания вызовет переполнение.");
            }

            return left - right;
        }
    }
}
