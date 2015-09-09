using ActionImplementation;
using InterfaceActions.Actions;
using Ninject;
using Repository;
using Repository.Interfaces;

namespace Infrastructure.IoC
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<IDisplayInfoAction>().To<DisplayAll>();
            Kernel.Bind<ICompany>().To<ComapnyInfo>();
            Kernel.Bind<IContractorDisplay>().To<DisplayImportantInfo>();
            Kernel.Bind<IProject>().To<ProjectInfo>();
            Kernel.Bind<ITask>().To<TaskInfo>();
            Kernel.Bind<IPersonRepository>().To<PersonRepository>();
            Kernel.Bind<IPersonSkillsRepository>().To<PersonSkillsRepository>();
            Kernel.Bind<ICompanyRepository>().To<CompanyRepository>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}