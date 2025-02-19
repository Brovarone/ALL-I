using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFeeTemplates
    {
        public MaFeeTemplates()
        {
            MaFeeTemplatesDetail = new HashSet<MaFeeTemplatesDetail>();
        }

        public string FeeTpl { get; set; }
        public string Description { get; set; }
        public string Duty { get; set; }
        public double? WithholdingTaxPerc { get; set; }
        public double? WithholdingTaxBasePerc { get; set; }
        public double? TaxPerc { get; set; }
        public short? InpscalculationType { get; set; }
        public double? EnasarcopercSalesPerson { get; set; }
        public double? Enasarcoperc { get; set; }
        public string Form770Frame { get; set; }
        public double? EnasarcoassPerc { get; set; }
        public int? DutyType { get; set; }
        public string DirectorRemuneration { get; set; }
        public Guid? Tbguid { get; set; }
        public double? EnasarcoassPercSp { get; set; }
        public string WithholdingTaxAsTax { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaFeeTemplatesDetail> MaFeeTemplatesDetail { get; set; }
    }
}
