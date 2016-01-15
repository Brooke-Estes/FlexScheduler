namespace FlexScheduler.Integration
{
    using System;
    using System.Collections.Generic;
    using Entities;
    using NUnit.Framework;

    [TestFixture]
    public class Persistence : SessionBase
    {
        private const string City = "Topeka";
        private const string State = "KS";

        [TestCase( "Westridge Kiosk", "1801 SW Wanamaker Rd", "66604" )]
        [TestCase( "Hunters Ridge", "4731 NW Hunters Ridge Cir.", "66618" )]
        public void CanCreateStore(string name, string street, string zip)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var store = new Store
                    {
                        Name = name,
                        Street = street,
                        City = City,
                        State = State,
                        Zip = zip
                    };

                    session.Save(store);
                    trx.Commit();
                    Assert.AreNotEqual(store.Id,0);
                }
            }
        }

        private BusinessDay GetBusinessDay(int day, int start, int end)
        {
            return new BusinessDay
            {
                BusinessDate = new DateTime(2016, 1, day),
                StartOfDay = new DateTime(2016, 1, day, start, 0, 0),
                EndOfDay = new DateTime(2016, 1, day, end, 0, 0)
            };
        }

        [Test]
        public void CanCreateStoreHours()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var h1 = new BusinessHours
                    {
                        Name = "Westridge Kiosk",
                        StartOfWeek = new DateTime(2016, 1, 11),
                        EndOfWeek = new DateTime(2016, 1, 17),
                        Hours = new List<BusinessDay> { GetBusinessDay(11, 9, 17), GetBusinessDay(13, 9, 17) }
                    };

                    var h2 = new BusinessHours
                    {
                        Name = "Hunters Ridge",
                        StartOfWeek = new DateTime(2016, 1, 11),
                        EndOfWeek = new DateTime(2016, 1, 17),
                        Hours = new List<BusinessDay> { GetBusinessDay(12, 13, 17) }
                    };

                    session.Save(h1);
                    session.Save(h2);
                    trx.Commit();
                }
            }
           
        }

        [Test]
        public void CanCreateAvailabilities()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var availability = new Availaibility
                    {
                        FullName = "Jane Smith",
                        StartOfWeek = new DateTime(2016, 1, 11),
                        EndOfWeek = new DateTime(2016, 1, 17),
                        Hours = new List<BusinessDay>() {GetBusinessDay(11, 9, 12), GetBusinessDay(13, 9, 3)}
                    };

                    session.Save(availability);
                    trx.Commit();

                    Assert.AreNotEqual(availability.Id, 0);
                }
            }
        }
        
    }
}