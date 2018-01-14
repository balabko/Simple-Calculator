using System;

namespace SimpleCalculator.App.CalculatorStreamReader
{
    public interface ICalculatorStreamReader
    {
        string ReadKey(ConsoleKeyInfo key);
    }
}
