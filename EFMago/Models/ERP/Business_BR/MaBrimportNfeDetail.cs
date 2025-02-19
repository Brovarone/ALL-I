using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrimportNfeDetail
    {
        public int DocumentId { get; set; }
        public short Line { get; set; }
        public string ItemCons { get; set; }
        public string ItemSend { get; set; }
        public string BarcodeSend { get; set; }
        public string DescriptionSend { get; set; }
        public string UoMSend { get; set; }
        public double? QtySend { get; set; }
        public string UoMofQtySendCons { get; set; }
        public string BaseUoMCons { get; set; }
        public double? QtyInBaseUoMCons { get; set; }
        public double? UnitValueSend { get; set; }
        public string TaxRuleCodeCons { get; set; }
        public double? TaxableAmountSend { get; set; }
        public double? TotalAmountSend { get; set; }
        public double? DiscountAmountSend { get; set; }
        public double? DistrShipChargesSend { get; set; }
        public double? DistrAdditionalChargesSend { get; set; }
        public double? DistrInsuranceChargesSend { get; set; }
        public double? DistrDiscountSend { get; set; }
        public string CfopSend { get; set; }
        public string NcmSend { get; set; }
        public short? ExtipiSend { get; set; }
        public short? GoodsOriginSend { get; set; }
        public double? IiTaxableSend { get; set; }
        public double? IiValueSend { get; set; }
        public double? IiPercSend { get; set; }
        public double? IpiTaxableSend { get; set; }
        public double? IpiValueSend { get; set; }
        public double? IpiPercSend { get; set; }
        public string IpiCodeSend { get; set; }
        public double? PisTaxableSend { get; set; }
        public double? PisValueSend { get; set; }
        public double? PisPercSend { get; set; }
        public string PisCodeSend { get; set; }
        public double? CofinsTaxableSend { get; set; }
        public double? CofinsValueSend { get; set; }
        public double? CofinsPercSend { get; set; }
        public string CofinsCodeSend { get; set; }
        public double? SimplesTaxableSend { get; set; }
        public double? SimplesValueSend { get; set; }
        public double? SimplesPercSend { get; set; }
        public string SimplesCodeSend { get; set; }
        public double? IcmsTaxableSend { get; set; }
        public double? IcmsValueSend { get; set; }
        public double? IcmsPercSend { get; set; }
        public double? IcmsReductionPercSend { get; set; }
        public string IcmsCodeSend { get; set; }
        public short? IcmsModSend { get; set; }
        public short? IcmsNoTaxReasonSend { get; set; }
        public double? IcmsstTaxableSend { get; set; }
        public double? IcmsstValueSend { get; set; }
        public double? IcmsstPercSend { get; set; }
        public double? IcmsstReductionPercSend { get; set; }
        public double? IcmssttoBeCompPercSend { get; set; }
        public string IcmsstCodeSend { get; set; }
        public double? MvaPercSend { get; set; }
        public string TaxRuleCodeCompanyCons { get; set; }
        public string DetailErrorsCons { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaBrimportNfe Document { get; set; }
    }
}
