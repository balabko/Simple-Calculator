using Ninject.Modules;
using SimpleCalculator.App.CalculatorStreamReader;
using SimpleCalculator.App.CalculatorStreamReader.CalculatorStreamReaderStateExecutor;
using SimpleCalculator.App.Helper;
using SimpleCalculator.Core;
using SimpleCalculator.InputManagement;
using SimpleCalculator.ULongCalculator;

namespace SimpleCalculator.App.Infrastructure
{
    public class ULongCalculatorNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISCBinOperationFactory<ulong>>().To<ULongOperationFactory>();
            Bind<ISCStringConverter<ulong>>().To<ULongSCStringConverter>();
            Bind<ISCProcessor<ulong>>().To<SCProcessor<ulong>>();
            Bind<ISCInputManager>().To<SCInputManager<ulong>>();
            Bind<IStateExecutorFactory>().To<StateExecutorFactory>();
            Bind<ICalculatorStreamReader>().To<CalculatorStreamReader.CalculatorStreamReader>();
            Bind<IHelper>().To<Helper.Helper>();
        }
    }
}
