using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWtparametersWorker
    {
        public short Id { get; set; }
        public int Worker { get; set; }
        public string EditBin { get; set; }
        public string EditLot { get; set; }
        public string InsertForDifference { get; set; }
        public string SortByTosNumber { get; set; }
        public int? SortTotype { get; set; }
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
        public string AllowSysAndParamSettings { get; set; }
        public string AllowManufacturingPutaway { get; set; }
        public string AllowManufacturingPicking { get; set; }
        public string AllowGoodsReceipt { get; set; }
        public string AllowToautoassignment { get; set; }
        public string EditPackInPicking { get; set; }
        public string EditItemInPicking { get; set; }
        public string AllowHigherQtyInPicking { get; set; }
        public string EditBinPicking { get; set; }
        public string AllowQtyMissinginPicking { get; set; }
        public string AllowQtyBrokeninPicking { get; set; }
        public string EditUoMinPicking { get; set; }
        public string CheckItemQtyForInventory { get; set; }
        public string ItemsCounter { get; set; }
        public string ItemsCounterPutaway { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaWtparameters IdNavigation { get; set; }
    }
}
