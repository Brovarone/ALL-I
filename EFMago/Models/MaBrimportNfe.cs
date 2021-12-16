using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrimportNfe
    {
        public MaBrimportNfe()
        {
            MaBrimportNfeDetail = new HashSet<MaBrimportNfeDetail>();
            MaBrimportNfeRef = new HashSet<MaBrimportNfeRef>();
        }

        public int DocumentId { get; set; }
        public string CustSuppCons { get; set; }
        public int? CustSuppTypeCons { get; set; }
        public DateTime? InstallmStartDate { get; set; }
        public string ChNfeSend { get; set; }
        public string ModelSend { get; set; }
        public string SeriesSend { get; set; }
        public string DocNoSend { get; set; }
        public DateTime? DocumentDateSend { get; set; }
        public string OperationDescriptionSend { get; set; }
        public string PaymentTypeSend { get; set; }
        public string TaxIdNumberSend { get; set; }
        public string FiscalCodeSend { get; set; }
        public string CompanyNameSend { get; set; }
        public string CityNameSend { get; set; }
        public string CountryNameSend { get; set; }
        public string FederalStateSend { get; set; }
        public string TelephoneSend { get; set; }
        public string AddressSend { get; set; }
        public string Address2Send { get; set; }
        public string CityCodeSend { get; set; }
        public string IsocountryCodeSend { get; set; }
        public string DistrictSend { get; set; }
        public string FantasyNameSend { get; set; }
        public string StreetNoSend { get; set; }
        public string ZipcodeSend { get; set; }
        public string FedStateRegSend { get; set; }
        public string FedStateRegStSend { get; set; }
        public string GoodsActivitySend { get; set; }
        public string MunicipalityRegSend { get; set; }
        public string TaxIdNumberCons { get; set; }
        public string FiscalCodeCons { get; set; }
        public string CompanyNameCons { get; set; }
        public string CityNameCons { get; set; }
        public string FederalStateCons { get; set; }
        public string PaymentCons { get; set; }
        public string NotaFiscalCodeCons { get; set; }
        public DateTime? ProcessDateCons { get; set; }
        public DateTime? ConsultDateCons { get; set; }
        public DateTime? ImportDateCons { get; set; }
        public DateTime? ReceiptDateCons { get; set; }
        public double? ShipChargesSend { get; set; }
        public double? AdditionalChargesSend { get; set; }
        public double? InsuranceChargesSend { get; set; }
        public double? GoodsAmountSend { get; set; }
        public double? TotalAmountSend { get; set; }
        public double? DiscountAmountSend { get; set; }
        public double? IiValueSend { get; set; }
        public double? IpiValueSend { get; set; }
        public double? PisValueSend { get; set; }
        public double? CofinsValueSend { get; set; }
        public double? IcmsValueSend { get; set; }
        public double? IcmsstValueSend { get; set; }
        public double? IcmsexValueSend { get; set; }
        public double? IcmstotTaxableValueSend { get; set; }
        public double? IcmssttotTaxableValueSend { get; set; }
        public string TransportCons { get; set; }
        public short? ShippingModeSend { get; set; }
        public string PackageSend { get; set; }
        public string AppearanceSend { get; set; }
        public short? NoOfPacksSend { get; set; }
        public double? NetWeightSend { get; set; }
        public double? GrossWeightSend { get; set; }
        public DateTime? DepartureDateSend { get; set; }
        public short? DepartureHrSend { get; set; }
        public short? DepartureMnSend { get; set; }
        public string FiscalMessageSend { get; set; }
        public string HeadErrorsCons { get; set; }
        public string PymtCashCons { get; set; }
        public string PymtAccountCons { get; set; }
        public string CostCenterCons { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaBrimportNfeDetail> MaBrimportNfeDetail { get; set; }
        public virtual ICollection<MaBrimportNfeRef> MaBrimportNfeRef { get; set; }
    }
}
