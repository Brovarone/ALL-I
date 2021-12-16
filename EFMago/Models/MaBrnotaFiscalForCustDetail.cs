using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnotaFiscalForCustDetail
    {
        public int SaleDocId { get; set; }
        public short Line { get; set; }
        public int? SubId { get; set; }
        public int? SubIdParent { get; set; }
        public string Cfop { get; set; }
        public double? IiTaxable { get; set; }
        public double? IiValue { get; set; }
        public double? IiPerc { get; set; }
        public double? IpiTaxable { get; set; }
        public double? IpiValue { get; set; }
        public double? IpiPerc { get; set; }
        public string IpiCode { get; set; }
        public string IpilegalCode { get; set; }
        public double? PisTaxable { get; set; }
        public double? PisValue { get; set; }
        public double? PisPerc { get; set; }
        public string PisCode { get; set; }
        public double? CofinsTaxable { get; set; }
        public double? CofinsValue { get; set; }
        public double? CofinsPerc { get; set; }
        public string CofinsCode { get; set; }
        public double? SimplesTaxable { get; set; }
        public double? SimplesValue { get; set; }
        public double? SimplesPerc { get; set; }
        public string SimplesCode { get; set; }
        public double? SuframaTaxable { get; set; }
        public double? SuframaValue { get; set; }
        public double? SuframaPerc { get; set; }
        public double? IcmsTaxable { get; set; }
        public double? IcmsValue { get; set; }
        public double? IcmsPerc { get; set; }
        public double? IcmsReductionPerc { get; set; }
        public string IcmsCode { get; set; }
        public double? IcmsstTaxable { get; set; }
        public double? IcmsstValue { get; set; }
        public double? IcmsstPerc { get; set; }
        public double? MvaPerc { get; set; }
        public double? IcmsstReductionPerc { get; set; }
        public string IcmsstCode { get; set; }
        public double? IcmssttoBeCompPerc { get; set; }
        public string Ncm { get; set; }
        public short? Extipi { get; set; }
        public short? IcmsMod { get; set; }
        public short? IcmsstMod { get; set; }
        public short? IcmsNoTaxReason { get; set; }
        public double? IcmsexTaxable { get; set; }
        public double? IcmsexValue { get; set; }
        public double? IcmsexPerc { get; set; }
        public string IcmsexCode { get; set; }
        public double? IcmsdefTaxable { get; set; }
        public double? IcmsdefValue { get; set; }
        public double? IcmsdefPerc { get; set; }
        public string IcmsdefCode { get; set; }
        public short? GoodsOrigin { get; set; }
        public string TaxMessageCode1 { get; set; }
        public string TaxMessageCode2 { get; set; }
        public string Cfopcompany { get; set; }
        public string IcmsCodeCompany { get; set; }
        public string IpiCodeCompany { get; set; }
        public string PisCodeCompany { get; set; }
        public string CofinsCodeCompany { get; set; }
        public string SimplesCodeCompany { get; set; }
        public int? Icmstype { get; set; }
        public int? Icmssttype { get; set; }
        public int? Ipitype { get; set; }
        public int? Pistype { get; set; }
        public int? Cofinstype { get; set; }
        public double? IcmsdestTaxable { get; set; }
        public double? IcmsdestPerc { get; set; }
        public double? IcmsinterPerc { get; set; }
        public double? IcmsdestTempPerc { get; set; }
        public double? IcmsdestValue { get; set; }
        public double? IcmsorigValue { get; set; }
        public double? IcmsfcpPerc { get; set; }
        public double? IcmsfcpValue { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSaleDoc SaleDoc { get; set; }
    }
}
