using ActionImplementation;
using InterfaceActions.Actions;
using Ninject;



namespace Infrastructure.IoC
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<IDisplayInfoAction>().To<DisplayAll>();
            Kernel.Bind<ICompany>().To<ComapnyInfo>();
            Kernel.Bind<IProject>().To<ProjectInfo>();
            Kernel.Bind<IContractorDisplay>().To<DisplayImportantInfo>();
            //Kernel.Bind<>
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}