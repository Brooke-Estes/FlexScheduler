namespace FlexScheduler.Integration
{
    using System.Configuration;
    using Domain.ClassMaps;
    using Entities;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    [TestFixture]
    public abstract class SessionBase
    {
        public ISessionFactory _sessionFactory;

        [SetUp]
        public void SetContext()
        {
            var cnx = ConfigurationManager.ConnectionStrings["FlexSchedulerHome"].ConnectionString;

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(cnx)
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StoreClassMap>())
                .BuildSessionFactory();
        }

        [TearDown]
        public void TearDown()
        {
            if (_sessionFactory != null) 
                _sessionFactory.Close();
        }
    }
}