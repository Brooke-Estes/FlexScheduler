namespace FlexScheduler.Domain.ClassMaps
{
    using Entities;
    using FluentNHibernate.Mapping;

    public class BusinessHoursBaseClassMap : ClassMap<BusinessHoursBase>
    {
        public BusinessHoursBaseClassMap()
        {
            Table("BusinessHours");
            Id(x => x.Id);
            
            DiscriminateSubClassesOnColumn("EntityType")
                .AlwaysSelectWithValue();
            
            Map(x => x.StartOfWeek);
            Map(x => x.EndOfWeek);
            Map(x => x.Hours).CustomType<JsonCollectionType<BusinessDay>>();
            
        }
    }
}