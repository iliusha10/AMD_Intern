using Domain;

namespace Repository.Interfaces
{
    public interface IRepository
    {
        #region Public members

        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;

        #endregion
    }
}