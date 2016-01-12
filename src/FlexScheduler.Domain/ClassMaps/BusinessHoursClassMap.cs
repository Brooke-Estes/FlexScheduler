namespace FlexScheduler.Domain.ClassMaps
{
    using Entities;
    using FluentNHibernate.Mapping;

    public class BusinessHoursClassMap : ClassMap<BusinessHours>
    {
        public BusinessHoursClassMap()
        {
            Table("BusinessHours");
            Id(x => x.Id);

            DiscriminateSubClassesOnColumn("Discriminator", "Store")
                .AlwaysSelectWithValue();

            Map(x => x.Store);
            Map(x => x.StartOfWeek);
            Map(x => x.EndOfWeek);
            Map(x => x.Hours).CustomType<JsonCollectionType<BusinessDay>>();
            
        }
    }
}