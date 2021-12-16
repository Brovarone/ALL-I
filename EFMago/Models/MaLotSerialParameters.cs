using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLotSerialParameters
    {
        public int LotSerialParametersId { get; set; }
        public string UseLots { get; set; }
        public string LotsAutoNum { get; set; }
        public int? LotSelection { get; set; }
        public string EnableLotsOnNewItems { get; set; }
        public string LotOnPurchaseIsMand { get; set; }
        public string LotOnSaleIsMand { get; set; }
        public string WarnNoLotInPurch { get; set; }
        public string WarnNoLotInSale { get; set; }
        public int? ChooseLotOnPicking { get; set; }
        public string OldLot { get; set; }
        public string ExcludedFromOnHand { get; set; }
        public short? SerialMaxDigits { get; set; }
        public int? LotsTracingActionInBom { get; set; }
        public string EnableLotsTracing { get; set; }
        public string LotOnInvEntryIsMand { get; set; }
        public string WarnNoLotInInvEntry { get; set; }
        public string TraceAlsoWithoutParent { get; set; }
        public string HideLotDescription { get; set; }
        public short? LotMaxDigits { get; set; }
        public string UniqueLotNumbering { get; set; }
        public string LotsValuesAreUpdatedByCost { get; set; }
        public string AutoCreation { get; set; }
        public string DisplayOutofStocksLots { get; set; }
        public string UseSupplierLotAsNewLotNumber { get; set; }
        public string DisplaySupplierLot { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
