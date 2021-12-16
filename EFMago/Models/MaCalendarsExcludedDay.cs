using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCalendarsExcludedDay
    {
        public string Calendar { get; set; }
        public short Line { get; set; }
        public DateTime? StartingDay { get; set; }
        public DateTime? EndingDay { get; set; }
        public string ReasonOfExclusion { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCalendars CalendarNavigation { get; set; }
    }
}
