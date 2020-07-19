
using Ninject;
using TravelRouteConsole.Contoller;

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
            KernelIoC.Bind<TravelRouteController>().ToSelf();
        }

        public static T Get<T>()
        {
            if (_kernel == null)
                Registrar();

            return _kernel.Get<T>();
        }
    }
}
