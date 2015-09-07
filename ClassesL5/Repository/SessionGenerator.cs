using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository
{
    public class SessionGenerator
    {
        #region Public static members

        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }

        #endregion

        #region Public members

        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        #endregion

        #region Non-public static members

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private static ISessionFactory CreateSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(builder => builder.Database("Person")
                        //.Server(@"MDDSK40107")
                        .Server(@"SHADHOME-PC")
                        .TrustedConnection()))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof (PersonMap).Assembly))
                .ExposeConfiguration(
                    cfg => new SchemaUpdate(cfg).Execute(true, true));





            return configuration.BuildSessionFactory();
        }

        #endregion

        #region Non-public members

        private SessionGenerator()
        {
        }

        #endregion
    }
}