namespace FlexScheduler.Entities
{
    using System;

    public class BusinessDay
    {
        public DateTime BusinessDate { get; set; }

        public DateTime StartOfDay { get; set; }

        public DateTime EndOfDay { get; set; }
    }
}
