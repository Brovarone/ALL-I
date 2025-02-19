using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxJournals
    {
        public MaTaxJournals()
        {
            MaTaxJournalsRange = new HashSet<MaTaxJournalsRange>();
        }

        public string TaxJournal { get; set; }
        public string Description { get; set; }
        public int? CodeType { get; set; }
        public string Euannotation { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public string ExcludedFromProRata { get; set; }
        public string ExcludedFromVat { get; set; }
        public string SpecialPrint { get; set; }
        public string AutomaticNumbering { get; set; }
        public string IsAprotocol { get; set; }
        public short? BranchNumber { get; set; }
        public string MarginTax { get; set; }
        public Guid? Tbguid { get; set; }
        public string IsTravelAgencyJournal { get; set; }
        public string InTravelAgencyCalculation { get; set; }
        public string Omniasection { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaTaxJournalsRange> MaTaxJournalsRange { get; set; }
    }
}
