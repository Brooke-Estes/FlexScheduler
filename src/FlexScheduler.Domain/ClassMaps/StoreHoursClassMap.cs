namespace FlexScheduler.Domain.ClassMaps
{
    using Entities;
    using FluentNHibernate.Mapping;

    public class StoreHoursClassMap : SubclassMap<StoreHours>
    {
        public StoreHoursClassMap()
        {
            Map(x => x.Name);
            DiscriminatorValue("Store");
        }
    }
}