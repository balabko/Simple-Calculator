using System;
using System.Reflection;
using Ninject;
using SimpleCalculator.App.CalculatorStreamReader;
using SimpleCalculator.App.Helper;

namespace SimpleCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var ninjectKernel = new StandardKernel();
            ninjectKernel.Load(Assembly.GetExecutingAssembly());

            var helper = ninjectKernel.Get<IHelper>();
            var calculatorStreamReader = ninjectKernel.Get<ICalculatorStreamReader>();
            
            Console.Write(helper.GetHelp());
            Console.Write("\n\n");

            ConsoleKeyInfo key;
            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                Console.Write(calculatorStreamReader.ReadKey(key));
            }
        }
    }
}
