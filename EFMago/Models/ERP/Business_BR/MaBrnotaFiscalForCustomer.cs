using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnotaFiscalForCustomer
    {
        public int SaleDocId { get; set; }
        public string NotaFiscalCode { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public string ServiceTypeCode { get; set; }
        public string Numbered { get; set; }
        public string ChNfe { get; set; }
        public string NProt { get; set; }
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
        public string CancReason { get; set; }
        public string NProtCancNfe { get; set; }
        public string ThirdParties { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? ConsultDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public DateTime? ImportDate { get; set; }
        public string StartContingency { get; set; }
        public string PostedToRomaneio { get; set; }
        public int? CustPresenceIndicator { get; set; }
        public string InventoryReasonAdjust { get; set; }
        public int? InventoryAdjustId { get; set; }
        public string FiscalMessage { get; set; }
        public string DocNoNfservices { get; set; }
        public DateTime? DocDateNfservices { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSaleDoc SaleDoc { get; set; }
    }
}
