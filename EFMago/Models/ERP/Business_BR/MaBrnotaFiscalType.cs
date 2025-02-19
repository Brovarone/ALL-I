using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnotaFiscalType
    {
        public MaBrnotaFiscalType()
        {
            MaBrnotaFiscalTypeDetail = new HashSet<MaBrnotaFiscalTypeDetail>();
        }

        public string NotaFiscalCode { get; set; }
        public string Description { get; set; }
        public string IsstaxRateCode { get; set; }
        public short? CustSuppType { get; set; }
        public short? MovementType { get; set; }
        public string InventoryReason { get; set; }
        public string InventoryReasonAdjust { get; set; }
        public string AutoNumbering { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public string Cfopgroup { get; set; }
        public string ForGoods { get; set; }
        public string DistributeChargesByLines { get; set; }
        public string NotaFiscalAccTpl { get; set; }
        public string NotaFiscalAccRsn { get; set; }
        public string AdvanceAccRsn { get; set; }
        public string FreeSamplesAccRsn { get; set; }
        public string GoodsAccount { get; set; }
        public string ServicesAccount { get; set; }
        public string FreeSamplesAmount { get; set; }
        public string Advance { get; set; }
        public string ShippingCharges { get; set; }
        public string AdditionalCharges { get; set; }
        public string InsuranceCharges { get; set; }
        public short? DanfetypePrint { get; set; }
        public string ExcludedFromTot { get; set; }
        public string ExcludeElectrTransm { get; set; }
        public string EnableOrigDest { get; set; }
        public string EnableNfeRef { get; set; }
        public string EnableApproxTaxesMsg { get; set; }
        public string SimplesMsg { get; set; }
        public string SimplesZeroMsg { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string ApproxTaxesMsg { get; set; }
        public int? IncludedInTurnover { get; set; }
        public int? NfeIssuingPurpose { get; set; }
        public int? CustPresenceIndicator { get; set; }
        public short? OperationType { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaBrnotaFiscalTypeDetail> MaBrnotaFiscalTypeDetail { get; set; }
    }
}
