using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnotaFiscalForCustSummary
    {
        public int SaleDocId { get; set; }
        public double? IiValue { get; set; }
        public double? IpiValue { get; set; }
        public double? PisValue { get; set; }
        public double? CofinsValue { get; set; }
        public double? SimplesValue { get; set; }
        public double? IcmsValue { get; set; }
        public double? IcmsstValue { get; set; }
        public double? IcmsexValue { get; set; }
        public double? IcmsdefValue { get; set; }
        public double? SuframaValue { get; set; }
        public double? InsuranceCharges { get; set; }
        public string InsuranceChargesIsAuto { get; set; }
        public double? DeductionIss { get; set; }
        public string DeductionReason { get; set; }
        public double? ServicesIrValue { get; set; }
        public double? ServicesIrPerc { get; set; }
        public double? ServicesIssValue { get; set; }
        public double? ServicesIssPerc { get; set; }
        public double? ServicesInssValue { get; set; }
        public double? ServicesInssPerc { get; set; }
        public double? ServicesPisValue { get; set; }
        public double? ServicesPisPerc { get; set; }
        public double? ServicesCofinsValue { get; set; }
        public double? ServicesCofinsPerc { get; set; }
        public double? ServicesCsValue { get; set; }
        public double? ServicesCsPerc { get; set; }
        public double? IcmstotTaxableValue { get; set; }
        public double? IcmssttotTaxableValue { get; set; }
        public string AdvancePymtCash { get; set; }
        public string AdvancePymtAccount { get; set; }
        public string ServicesIrValueIsAuto { get; set; }
        public string ServicesInssValueIsAuto { get; set; }
        public string ServicesCsValueIsAuto { get; set; }
        public string ServicesPisValueIsAuto { get; set; }
        public string ServicesCofinsValueIsAuto { get; set; }
        public string IsstaxRateCode { get; set; }
        public string IsstaxRateCodeIsAuto { get; set; }
        public double? IcmsdestValue { get; set; }
        public double? IcmsorigValue { get; set; }
        public double? IcmsfcpValue { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSaleDoc SaleDoc { get; set; }
    }
}
