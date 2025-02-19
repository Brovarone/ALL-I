using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrtaxRules
    {
        public string TaxRuleCode { get; set; }
        public string Description { get; set; }
        public short? Priority { get; set; }
        public DateTime ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string Ncm { get; set; }
        public short? Extipi { get; set; }
        public string ItemFiscalCtg { get; set; }
        public string Item { get; set; }
        public string FederalState { get; set; }
        public string CustSuppFiscalCtg { get; set; }
        public short? GoodsOrigin { get; set; }
        public string Cfop { get; set; }
        public string PiscalcCode { get; set; }
        public string CofinscalcCode { get; set; }
        public string IpicalcCode { get; set; }
        public string SuframacalcCode { get; set; }
        public string SimplescalcCode { get; set; }
        public string IitaxRateCode { get; set; }
        public string IitaxFormulaCode { get; set; }
        public string IcmstaxCode { get; set; }
        public string IcmstaxRateCode { get; set; }
        public string IcmsexTaxRateCode { get; set; }
        public string IcmsdefTaxRateCode { get; set; }
        public string IcmsreducTaxRateCode { get; set; }
        public string IcmstaxFormulaCode { get; set; }
        public string IcmsexTaxFormulaCode { get; set; }
        public string IcmsdefTaxFormulaCode { get; set; }
        public string IcmssttaxRateCode { get; set; }
        public string MvataxRateCode { get; set; }
        public string IcmssttoBeCompTaxRateCode { get; set; }
        public string IcmssttaxFormulaCode { get; set; }
        public string IcmsstreducTaxRateCode { get; set; }
        public string TaxMessageCode1 { get; set; }
        public string TaxMessageCode2 { get; set; }
        public short? MovementType { get; set; }
        public short? IcmsMod { get; set; }
        public short? IcmsstMod { get; set; }
        public short? IcmsNoTaxReason { get; set; }
        public string AllItems { get; set; }
        public string ExcludeIcmsst { get; set; }
        public string DistributeCharges { get; set; }
        public string IpilegalCode { get; set; }
        public string IcmsdestTaxRateCode { get; set; }
        public string IcmsdestTaxFormulaCode { get; set; }
        public string IcmsinterTaxRateCode { get; set; }
        public string IcmsdestTempRateCode { get; set; }
        public string IcmsorigTaxFormulaCode { get; set; }
        public string IcmsfcptaxRateCode { get; set; }
        public string IcmsfcptaxFormulaCode { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
