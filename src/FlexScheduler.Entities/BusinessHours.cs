namespace FlexScheduler.Entities
{
    using System;
    using System.Collections.Generic;

    public abstract  class BusinessHours
    {
        public virtual long Id { get; set; }
        
        public virtual DateTime StartOfWeek { get; set; }

        public virtual DateTime EndOfWeek { get; set; }

        public virtual List<BusinessDay> Hours { get; set; } 
    }
}