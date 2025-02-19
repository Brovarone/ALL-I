using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCalendars
    {
        public MaCalendars()
        {
            MaCalendarsExcludedDay = new HashSet<MaCalendarsExcludedDay>();
            MaCalendarsShift = new HashSet<MaCalendarsShift>();
        }

        public string Calendar { get; set; }
        public string Description { get; set; }
        public short? ExcludedDays { get; set; }
        public short? ExcludedMonths { get; set; }
        public short? ShiftDays { get; set; }
        public string MoveShiftsOnExclDays { get; set; }
        public string Notes { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCalendarsExcludedDay> MaCalendarsExcludedDay { get; set; }
        public virtual ICollection<MaCalendarsShift> MaCalendarsShift { get; set; }
    }
}
