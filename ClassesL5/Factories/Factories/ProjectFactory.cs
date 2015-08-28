using System.Collections.Generic;
using Domain.Domain;
using Domain.Interfaces;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class ProjectFactory
    {
        private readonly IProject _displayInfoAction;
        private readonly List<INotify> _subscribers;

        public ProjectFactory(IProject displayInfoAction)
        {
            _subscribers = new List<INotify>();
            _displayInfoAction = displayInfoAction;
        }

        public Project CreateProject(Company company, string projectName, string decription)
        {
            var project = new Project(company, projectName, decription);
            Logger.Logger.AddToLog("ProjectFactory|CreateProject Project");
            OnProjectCreation(project);
            return project;
        }

        public void OnProjectCreation(Project project)
        {
            _displayInfoAction.ShowProjectInfo(project);
            Notify(project);
        }

        public void Subscribe(INotify subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void UnSubscribe(INotify subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }

        private void Notify(Project project)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Inform(project);
            }
        }
    }
}