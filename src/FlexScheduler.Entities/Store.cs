namespace FlexScheduler.Entities
{
    public class Store
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Zip { get; set; }
    }
}