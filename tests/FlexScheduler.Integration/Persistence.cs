namespace FlexScheduler.Integration
{
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

        [TestCase()]
        public void CanCreateStoreHours()
        {
            
        }
    }
}