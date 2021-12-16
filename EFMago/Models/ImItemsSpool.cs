using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImItemsSpool
    {
        public ImItemsSpool()
        {
            ImItemsSpoolWeee = new HashSet<ImItemsSpoolWeee>();
        }

        public int ImportId { get; set; }
        public string Supplier { get; set; }
        public DateTime? ImportDate { get; set; }
        public string Item { get; set; }
        public string ItemSupplierCode { get; set; }
        public string Description { get; set; }
        public double? BasePrice { get; set; }
        public string UoM { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public string ItemType { get; set; }
        public string CommodityCtg { get; set; }
        public string HomogeneousCtg { get; set; }
        public string Producer { get; set; }
        public string ProductCtg { get; set; }
        public string ProductSubCtg { get; set; }
        public double? StandardCost { get; set; }
        public double? LastCost { get; set; }
        public double? ItemSupplierPrice { get; set; }
        public double? MinimumOrderQty { get; set; }
        public double? SupplierDiscount1 { get; set; }
        public double? SupplierDiscount2 { get; set; }
        public string SupplierDiscountFormula { get; set; }
        public double? CartonQty { get; set; }
        public double? MultipleQtyOrder { get; set; }
        public double? MaximumQty { get; set; }
        public string ProductStatus { get; set; }
        public string DiscountFamily { get; set; }
        public string Barcode { get; set; }
        public int? BarcodeType { get; set; }
        public string Note { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public int? PriceMultiplier { get; set; }
        public string Currency { get; set; }
        public double? MultipliedBasePrice { get; set; }
        public double? MultipliedStandardCost { get; set; }
        public double? MultipliedLastCost { get; set; }
        public double? MultipliedItemSupplierPrice { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public string Weeectg { get; set; }
        public string WeeectgDescription { get; set; }
        public double? Weeeamount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<ImItemsSpoolWeee> ImItemsSpoolWeee { get; set; }
    }
}
