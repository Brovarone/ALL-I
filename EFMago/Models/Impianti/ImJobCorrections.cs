using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobCorrections
    {
        public ImJobCorrections()
        {
            ImJobCorrectionsDetails = new HashSet<ImJobCorrectionsDetails>();
            ImJobCorrectionsReferences = new HashSet<ImJobCorrectionsReferences>();
        }

        public int Jcid { get; set; }
        public string Job { get; set; }
        public int Jcno { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Approver { get; set; }
        public string Note { get; set; }
        public string Customer { get; set; }
        public string PriceList { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? TotCost { get; set; }
        public double? TotCostMinus { get; set; }
        public double? TotCostPlus { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<ImJobCorrectionsDetails> ImJobCorrectionsDetails { get; set; }
        public virtual ICollection<ImJobCorrectionsReferences> ImJobCorrectionsReferences { get; set; }
    }
}
