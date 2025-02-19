using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIntra
    {
        public MaIntra()
        {
            MaIntraArrivals1A = new HashSet<MaIntraArrivals1A>();
            MaIntraArrivals1B = new HashSet<MaIntraArrivals1B>();
            MaIntraArrivals1C = new HashSet<MaIntraArrivals1C>();
            MaIntraArrivals1D = new HashSet<MaIntraArrivals1D>();
            MaIntraDispatches2A = new HashSet<MaIntraDispatches2A>();
            MaIntraDispatches2B = new HashSet<MaIntraDispatches2B>();
            MaIntraDispatches2C = new HashSet<MaIntraDispatches2C>();
            MaIntraDispatches2D = new HashSet<MaIntraDispatches2D>();
        }

        public int? JournalEntryId { get; set; }
        public int IntrastatId { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Currency { get; set; }
        public double? Fixing { get; set; }
        public short? BalanceMonth { get; set; }
        public short? Quarter { get; set; }
        public short? BalanceYear { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime? AccrualDate { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaIntraArrivals1A> MaIntraArrivals1A { get; set; }
        public virtual ICollection<MaIntraArrivals1B> MaIntraArrivals1B { get; set; }
        public virtual ICollection<MaIntraArrivals1C> MaIntraArrivals1C { get; set; }
        public virtual ICollection<MaIntraArrivals1D> MaIntraArrivals1D { get; set; }
        public virtual ICollection<MaIntraDispatches2A> MaIntraDispatches2A { get; set; }
        public virtual ICollection<MaIntraDispatches2B> MaIntraDispatches2B { get; set; }
        public virtual ICollection<MaIntraDispatches2C> MaIntraDispatches2C { get; set; }
        public virtual ICollection<MaIntraDispatches2D> MaIntraDispatches2D { get; set; }
    }
}
