using System;
using SimpleCalculator.Core;

namespace SimpleCalculator.ULongCalculator
{
    public class ULongOperationFactory : ISCBinOperationFactory<ulong>
    {
        public ISCBinOperationCalculator<ulong> GetBinOperationCalculator(SCBinOperation operationType)
        {
            switch (operationType)
            {
                case SCBinOperation.Add: return new AddULongCalculator();
                case SCBinOperation.Subtract: return new SubtractULongCalculator();
                default:
                    throw new NotSupportedException("Такая операция не поддержвивается для калькулятора, работающего с типом ulong.");
            }
        }
    }
}
