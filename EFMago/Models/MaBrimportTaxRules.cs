using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrimportTaxRules
    {
        public string TaxRuleCode { get; set; }
        public DateTime ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string Description { get; set; }
        public short? Priority { get; set; }
        public string Ncm { get; set; }
        public string ItemFiscalCtg { get; set; }
        public string Item { get; set; }
        public string AllItems { get; set; }
        public string CustSuppFiscalCtg { get; set; }
        public string NotaFiscalCode { get; set; }
        public string OriginalCfop { get; set; }
        public string Cfop { get; set; }
        public string IcmstaxCode { get; set; }
        public string IcmssttaxCode { get; set; }
        public string IpitaxCode { get; set; }
        public string PistaxCode { get; set; }
        public string CofinstaxCode { get; set; }
        public string SimplestaxCode { get; set; }
        public int? Icmstype { get; set; }
        public int? Icmssttype { get; set; }
        public int? Ipitype { get; set; }
        public int? Pistype { get; set; }
        public int? Cofinstype { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
