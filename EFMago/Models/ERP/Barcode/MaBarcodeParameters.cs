using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBarcodeParameters
    {
        public short Id { get; set; }
        public short? PrefixBarcodeStructureLength { get; set; }
        public short? ItemBarcodeLength { get; set; }
        public short? UoMbarcodeLength { get; set; }
        public short? LotBarcodeLength { get; set; }
        public short? QtyBarcodeLength { get; set; }
        public short? QtyDecBarcodeLength { get; set; }
        public short? WeightBarcodeLength { get; set; }
        public short? WeightDecBarcodeLength { get; set; }
        public short? VolumeBarcodeLength { get; set; }
        public short? VolumeDecBarcodeLength { get; set; }
        public short? MobarcodeLength { get; set; }
        public short? PurchOrderBarcodeLength { get; set; }
        public short? SubarcodeLength { get; set; }
        public short? BinBarcodeLength { get; set; }
        public string ConformingBarcode { get; set; }
        public short? ConformingKey { get; set; }
        public string RejectedBarcode { get; set; }
        public short? RejectedKey { get; set; }
        public string ReturnBarcode { get; set; }
        public short? ReturnKey { get; set; }
        public string ToBeInspBarcode { get; set; }
        public short? ToBeInspKey { get; set; }
        public string ScrapBarcode { get; set; }
        public short? ScrapKey { get; set; }
        public string PackBarcode { get; set; }
        public short? PackKey { get; set; }
        public string CancelBarcode { get; set; }
        public short? CancelKey { get; set; }
        public string CloseBarcode { get; set; }
        public short? CloseKey { get; set; }
        public string ScanStart { get; set; }
        public string ScanEnd { get; set; }
        public string NotConfigured { get; set; }
        public string UseStandardTerminator { get; set; }
        public string UseScanStartEnd { get; set; }
        public string CreateNewNumbersOnCloseSu { get; set; }
        public string UseBarcodeStructure { get; set; }
        public string UseGs1 { get; set; }
        public string UseItemBarcode { get; set; }
        public string UseItemSupplierBarcode { get; set; }
        public string Gs1lotExpDatePrev { get; set; }
        public short? InternalIdNoBarcodeLength { get; set; }
        public string UseIdnumber { get; set; }
        public string LogoPicture { get; set; }
        public string SaveBarcode { get; set; }
        public short? SaveKey { get; set; }
        public string NotAssignBarcodeInPuchOrd { get; set; }
        public string AcquireIdNoInScannerForm { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
