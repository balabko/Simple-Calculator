using System;
using SimpleCalculator.Core;

namespace SimpleCalculator.ULongCalculator
{
    public class AddULongCalculator : ISCBinOperationCalculator<ulong>
    {
        public ulong Execute(ulong left, ulong right)
        {
            if (ulong.MaxValue - left < right)
            {
                throw new OverflowException("Такая операция сложения вызовет переполнение.");
            }
            
            return left + right;
        }
    }
}
