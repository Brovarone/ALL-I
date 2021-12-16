using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmparameters
    {
        public short Id { get; set; }
        public string EditSaleDoc { get; set; }
        public string EditPurchaseDoc { get; set; }
        public string EditInventory { get; set; }
        public string EditBin { get; set; }
        public string EditLot { get; set; }
        public string EditInternalIdNo { get; set; }
        public string InsertMissing { get; set; }
        public string InsertForDifference { get; set; }
        public string InsertBroken { get; set; }
        public string ReasonGr { get; set; }
        public string ReasonGi { get; set; }
        public string ReasonPutaway { get; set; }
        public string ReasonPicking { get; set; }
        public string ReasonStockTransfer { get; set; }
        public string ReasonReplenishment { get; set; }
        public string ReasonInv { get; set; }
        public string ReasonBroken { get; set; }
        public string ReasonReturn { get; set; }
        public string ReasonMissing { get; set; }
        public string ReasonInterim { get; set; }
        public string ReasonPacking { get; set; }
        public string ReasonUnPacking { get; set; }
        public string ReasonReturnFromInspection { get; set; }
        public string ReasonTransferRequest { get; set; }
        public string ReasonManufacturingGr { get; set; }
        public string ReasonManufacturingPutaway { get; set; }
        public string ReasonManufacturingGi { get; set; }
        public string ReasonManufacturingInterim { get; set; }
        public string ReasonManufacturingPk { get; set; }
        public string ReasonManufacturingReorder { get; set; }
        public string Team { get; set; }
        public string CheckStorageUnitType { get; set; }
        public string PreShipGroupByItem { get; set; }
        public string PreShipGroupByCustItem { get; set; }
        public string PreShipGroupByNone { get; set; }
        public string GoodReceiptGroupByItem { get; set; }
        public string GoodReceiptGroupByNone { get; set; }
        public short? StorageUnitLength { get; set; }
        public string StorageUnitType { get; set; }
        public string AutomaticAssignResource { get; set; }
        public int? DefaultResource { get; set; }
        public string AutomaticChargesRec { get; set; }
        public string MaintainCharges { get; set; }
        public string ManualBinAssignment { get; set; }
        public string PreShippingBreakByCustomer { get; set; }
        public string PreShippingBreakBySaleOrdNo { get; set; }
        public string PreShippingBreakByCarrier { get; set; }
        public string PreShippingBreakByCustShipTo { get; set; }
        public string DenyPickQtyNotTotallyAvail { get; set; }
        public string Section { get; set; }
        public string ApplyUoMsameItem { get; set; }
        public string ReasonPickingCrossDocking { get; set; }
        public string ReasonPutawayCrossDocking { get; set; }
        public string CrossDockingPutStock { get; set; }
        public string CrossDockingPutCd { get; set; }
        public string ReasonInvClosing { get; set; }
        public string EditPackInPicking { get; set; }
        public string EditItemInPicking { get; set; }
        public string AllowHigherQtyInPicking { get; set; }
        public string UseSuppSerialAsNewSerialNo { get; set; }
        public string AllowHigherQtyInPreShipping { get; set; }
        public string PsautomaticChargesRec { get; set; }
        public string PsmaintainCharges { get; set; }
        public int? CheckTotoBeConfInDelDocGen { get; set; }
        public int? CheckAvailabilityInPsgen { get; set; }
        public string PreShipNotGroupBySu { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
