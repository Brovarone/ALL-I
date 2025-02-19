using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemParameters
    {
        public int ItemParametersId { get; set; }
        public short? CodeLength { get; set; }
        public string AutoAddItemCustomers { get; set; }
        public string AutoAddItemSuppliers { get; set; }
        public string AutoAddCommCtgCustomers { get; set; }
        public string AutoAddCommCtgSuppliers { get; set; }
        public double? BracketMaxQty { get; set; }
        public string UpdateQtyBracketPrices { get; set; }
        public string ItemAutoNum { get; set; }
        public int? LastItem { get; set; }
        public short? ItemMaxChars { get; set; }
        public string PunctualItemCustSuppUpdate { get; set; }
        public string CheckItemUoM { get; set; }
        public string StorageOnHandOnItemComboBox { get; set; }
        public string CheckExistItem { get; set; }
        public string ItemDraftDefault { get; set; }
        public int? ItemDraftType { get; set; }
        public string DefaultItemUoM { get; set; }
        public short? AdditionalCodeLength { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
