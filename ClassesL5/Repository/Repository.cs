using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository
{
    public abstract class Repository : IRepository
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Save(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Delete(entity);
        }
    }
}