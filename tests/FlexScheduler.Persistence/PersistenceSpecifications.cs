namespace FlexScheduler.Persistence
{
    using System;
    using System.Collections.Generic;
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
                        @"Server=BROOKE-PC\SQLEXPRESS;Initial Catalog=FlexScheduler; Integrated Security=true;"))
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
        public void CanPersistStore()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var newStore = new Store
                    {
                        Name = "Westridge Kiosk",
                        Street = "1149 SW Glendale Dr.",
                        City = "Topeka",
                        State = "KS",
                        Zip = "66604"
                    };

                    session.Save(newStore);
                    trx.Commit();

                    Assert.AreNotEqual(newStore.Id, 0);
                }
            }
        }

        [Test]
        public void CanPersistBusinessHours()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var newHours = new BusinessHours
                    {
                        Store = "Westridge Kiosk",
                        StartOfWeek = new DateTime(2016, 1, 11),
                        EndOfWeek = new DateTime(2016, 1, 17),
                        Hours = "Test"
                    };

                    session.Save(newHours);
                    trx.Commit();

                    Assert.AreNotEqual(newHours.Id, 0);
                }
            }
        }

        [Test]
        public void CanQuery()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var query = session.QueryOver<BusinessHours>()
                    .Where(s => s.Store == "WestridgeKiosk");

                var result = query.List();
            }
        }
    }

}