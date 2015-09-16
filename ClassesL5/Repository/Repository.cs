using System;
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

        public T GetItemById<T>(long id) where T : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var item = _session.Get<T>(id);
                    return item;
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("Repository | GetItemById | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }
    }
}