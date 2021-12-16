using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWtparameters
    {
        public MaWtparameters()
        {
            MaWtparametersWorker = new HashSet<MaWtparametersWorker>();
        }

        public short Id { get; set; }
        public string EditBin { get; set; }
        public string EditLot { get; set; }
        public string InsertForDifference { get; set; }
        public string SortByTosNumber { get; set; }
        public int? SortTotype { get; set; }
        public short? MonitorRefresh { get; set; }
        public string SyncTosWithErrors { get; set; }
        public string AllowAllOperations { get; set; }
        public string AllowPutaway { get; set; }
        public string AllowPicking { get; set; }
        public string AllowHandheldStockTransfer { get; set; }
        public string AllowIntMovementsConf { get; set; }
        public string AllowSpecialStockChange { get; set; }
        public string AllowPacking { get; set; }
        public string AllowInventory { get; set; }
        public string AllowPostDiffInventory { get; set; }
        public string AllowStockList { get; set; }
        public string AllowPrintLabel { get; set; }
        public string Smtp { get; set; }
        public string Email { get; set; }
        public int? ScanItemInPicking { get; set; }
        public string AllowSysAndParamSettings { get; set; }
        public string AllowManufacturingPutaway { get; set; }
        public string AllowManufacturingPicking { get; set; }
        public string AllowGoodsReceipt { get; set; }
        public string AllowToautoassignment { get; set; }
        public string ScanBinInPicking { get; set; }
        public string EditPackInPicking { get; set; }
        public string EditItemInPicking { get; set; }
        public string AllowHigherQtyInPicking { get; set; }
        public string EditBinPicking { get; set; }
        public string LoginByBarcode { get; set; }
        public string UseSerialNo { get; set; }
        public string UseSerialNoInPicking { get; set; }
        public string EditInternalIdNo { get; set; }
        public string AllowQtyMissinginPicking { get; set; }
        public string AllowQtyBrokeninPicking { get; set; }
        public string ItemsCounter { get; set; }
        public string AllowAllToautoassignment { get; set; }
        public string OnlyAlternativeItem { get; set; }
        public string OnlyManufAlternativeItem { get; set; }
        public int? CheckPresenceInBinForPicking { get; set; }
        public string SendEmailForPutaway { get; set; }
        public string SendEmailForPicking { get; set; }
        public string SendEmailForTransfer { get; set; }
        public string SendEmailForReplenishment { get; set; }
        public string SendEmailForReturns { get; set; }
        public string SendEmailForManuPick { get; set; }
        public string SendEmailForManuPut { get; set; }
        public string Diagnosticproblems { get; set; }
        public string ControlledPicking { get; set; }
        public string FlexiblePicking { get; set; }
        public string EditUoMinPicking { get; set; }
        public string TransferItemsUsedInWmsmobile { get; set; }
        public string CreateMobileDbonServer { get; set; }
        public string CheckItemOnHandQty { get; set; }
        public short? DelayBetweenRetry { get; set; }
        public short? NumRetryBeforeIdle { get; set; }
        public short? NumRetryBeforeError { get; set; }
        public string CheckItemQtyForInventory { get; set; }
        public short? MaxThreads { get; set; }
        public string CheckPickBeforeMoconfirmation { get; set; }
        public int? ScanItemInPutaway { get; set; }
        public string ItemsCounterPutaway { get; set; }
        public string ManufEditItemInPicking { get; set; }
        public string ManufEditUoMinPicking { get; set; }
        public string ManufEditLot { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public double? BlockIfConfirmedExceeds { get; set; }
        public string ShowItemOnHandQty { get; set; }
        public string GenToforDiffPreShipping { get; set; }
        public string GenToforDiffManufacturing { get; set; }

        public virtual ICollection<MaWtparametersWorker> MaWtparametersWorker { get; set; }
    }
}
