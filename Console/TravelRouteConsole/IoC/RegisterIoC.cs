using Ninject;
using TravelRouteConsole.Business;
using TravelRouteConsole.Business.Impl;
using TravelRouteConsole.Factory;
using TravelRouteConsole.Factory.Impl;
using TravelRouteConsole.Service;
using TravelRouteConsole.Service.Impl;

namespace TravelRouteConsole.IoC
{
    public class RegisterIoC
    {
        private static IKernel _kernel;
        public static IKernel KernelIoC
        {
            get
            {
                if (_kernel == null)
                    _kernel = new StandardKernel();
                return _kernel;
            }
        }
        public static void Registrar()
        {
            if (_kernel == null)
            {
                RegistrarClasses();
            }
        }

        private static void RegistrarClasses()
        {
            KernelIoC.Bind<ITravelRouteController>().To<TravelRouteController>();
            KernelIoC.Bind<IRouteFactory>().To<RouteFactory>();
            KernelIoC.Bind<IRouteReader>().To<CsvRouteReader>();
            KernelIoC.Bind<IUserInterface>().To<UserInterfaceConsole>();
            KernelIoC.Bind<IBestRouteService>().To<BestRouteService>();
            KernelIoC.Bind<IRouteService>().To<RouteService>();
            KernelIoC.Bind<ITravelRouteApi>().To<TravelRouteApi>();
        }

        public static T Get<T>()
        {
            if (_kernel == null)
                Registrar();

            return _kernel.Get<T>();
        }
    }
}
