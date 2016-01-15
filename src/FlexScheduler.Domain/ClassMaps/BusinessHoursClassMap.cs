namespace FlexScheduler.Domain.ClassMaps
{
    using Entities;
    using FluentNHibernate.Mapping;

    public class BusinessHoursClassMap : SubclassMap<BusinessHours>
    {
        public BusinessHoursClassMap()
        {
            Map(x => x.Name);
            DiscriminatorValue("Store");
        }
    }
}