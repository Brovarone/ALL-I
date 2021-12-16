using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMultiStorageParameters
    {
        public int MultiStorageParametersId { get; set; }
        public string UseReservedByStorage { get; set; }
        public string PurcOrdWarningMaximumStock { get; set; }
        public string PurchaseWarningMaximumStock { get; set; }
        public string InventoryWarningMaximumStock { get; set; }
        public int? InventoryShortageCheckType { get; set; }
        public int? SalesShortageCheckType { get; set; }
        public int? SalesOrdersShortageCheckType { get; set; }
        public int? InventoryScarcityCheckType { get; set; }
        public int? SalesScarcityCheckType { get; set; }
        public string AllocationByStorage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
