using Domain.CompanyAssets;
using InterfaceActions.Actions;

namespace ActionImplementation
{
    public class ProjectInfo : IProject
    {
        public void ShowProjectInfo(Project project)
        {
            project.DisplayAll();
        }
    }
}