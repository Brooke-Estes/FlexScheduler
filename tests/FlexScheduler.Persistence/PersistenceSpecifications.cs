namespace FlexScheduler.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Domain.ClassMaps;
    using Entities;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NUnit.Framework;

    [TestFixture]
    public class PersistenceSpecifications
    {
        private ISessionFactory _sessionFactory;

        [SetUp]
        public void SpecificationSetup()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ShowSql()
                    .ConnectionString(
                        @"Server=.;Initial Catalog=FlexScheduler; Integrated Security=true;"))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<StoreClassMap>())
                .BuildSessionFactory();
        }

        [TearDown]
        public void Teardown()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        [Test]
        public void CanPersistStoreHours()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var day1 = new BusinessDay()
                    {
                        BusinessDate = new DateTime(2016, 1, 11),
                        StartOfDay = new DateTime(2016, 1, 11, 9, 0, 0),
                        EndOfDay = new DateTime(2016, 1, 11, 17, 0, 0)
                    };

                    var hours = new StoreHours()
                    {
                        Name = "Westridge Kiosk",
                        StartOfWeek = new DateTime(2016, 1, 11),
                        EndOfWeek = new DateTime(2016, 1, 17),
                        Hours = new List<BusinessDay>() {day1}
                    };

                    session.Save(hours);
                    trx.Commit();
                    Assert.AreNotEqual(hours.Id,0);
                }
            }
        }

        [Test]
        public void CanQueryStoreHours()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var results = session.QueryOver<StoreHours>().Where(x => x.Name == "Westridge Kiosk").List();
                    Assert.IsNotNull(results);
                }
            }
        }
        
    }
}