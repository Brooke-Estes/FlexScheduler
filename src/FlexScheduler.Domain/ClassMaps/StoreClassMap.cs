namespace FlexScheduler.Domain.ClassMaps
{
    using Entities;
    using FluentNHibernate.Mapping;

    public class StoreClassMap : ClassMap<Store>
    {
        public StoreClassMap()
        {
            Table("Stores");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Street);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.Zip);
        }
    }
}