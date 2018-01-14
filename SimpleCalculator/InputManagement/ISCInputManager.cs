using System;
using SimpleCalculator.Core;

namespace SimpleCalculator.InputManagement
{
    public interface ISCInputManager
    {
        Exception Error { get; }

        void AddDigitChar(char digitChar);

        void RemoveLastDigit();

        int GetNumberLength();

        int FinishNumber();

        void SetOperation(SCBinOperation operation);

        void ResetNumber();

        void ResetError();

        void Reset();

        string GetResult();
    }
}
