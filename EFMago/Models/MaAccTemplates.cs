using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccTemplates
    {
        public MaAccTemplates()
        {
            MaAccTemplatesGldetail = new HashSet<MaAccTemplatesGldetail>();
            MaAccTemplatesRetailDetail = new HashSet<MaAccTemplatesRetailDetail>();
            MaAccTemplatesTaxDetail = new HashSet<MaAccTemplatesTaxDetail>();
        }

        public string Template { get; set; }
        public string Description { get; set; }
        public int? Operation { get; set; }
        public int? PaymentScheduleAction { get; set; }
        public int? DocNoIsMand { get; set; }
        public int? DocDateIsMand { get; set; }
        public string AccrualDeferral { get; set; }
        public int? CodeType { get; set; }
        public string TaxJournal { get; set; }
        public int? TaxSign { get; set; }
        public string CustSupp { get; set; }
        public string IntrastatOperation { get; set; }
        public string EutaxJournal { get; set; }
        public string Suspension { get; set; }
        public string Predefined { get; set; }
        public string Disabled { get; set; }
        public string GroupCode { get; set; }
        public string ReverseCharge { get; set; }
        public Guid? Tbguid { get; set; }
        public string ExcludedFromSac { get; set; }
        public string TypeOfTaxDocument { get; set; }
        public string TypeOfTaxDocumentAnn { get; set; }
        public string Currency { get; set; }
        public string PaymentScheduleCreditNote { get; set; }
        public int? ReverseChargeType { get; set; }
        public string TypeOfReverseCharge { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string Eicode { get; set; }
        public string PurchaseSplitPayment { get; set; }
        public int? EiintegrationType { get; set; }

        public virtual ICollection<MaAccTemplatesGldetail> MaAccTemplatesGldetail { get; set; }
        public virtual ICollection<MaAccTemplatesRetailDetail> MaAccTemplatesRetailDetail { get; set; }
        public virtual ICollection<MaAccTemplatesTaxDetail> MaAccTemplatesTaxDetail { get; set; }
    }
}
