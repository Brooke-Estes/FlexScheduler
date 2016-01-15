namespace FlexScheduler.Domain.ClassMaps
{
    using Entities;
    using FluentNHibernate.Mapping;

    public class AvailaibilityClassMap : SubclassMap<Availaibility>
    {
        public AvailaibilityClassMap()
        {
            Map(x => x.FullName).Column("Name");
            DiscriminatorValue("Employee");
        }
    }
}