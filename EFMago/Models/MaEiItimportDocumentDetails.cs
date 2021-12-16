using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEiItimportDocumentDetails
    {
        public int DocumentId { get; set; }
        public int Line { get; set; }
        public int? RowStatus { get; set; }
        public string Item { get; set; }
        public string UoM { get; set; }
        public string TaxCode { get; set; }
        public string NotInReverseCharge { get; set; }
        public string CodItemCust { get; set; }
        public string CodItemSupp { get; set; }
        public string BarCodeItem { get; set; }
        public string NomCombItem { get; set; }
        public string OtherCodeItem { get; set; }
        public string SaleType { get; set; }
        public string ItemDescr { get; set; }
        public double? ItemQty { get; set; }
        public string UoMdoc { get; set; }
        public double? UnitValue { get; set; }
        public double? DiscountPerc { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxCodeDoc { get; set; }
        public string ItemDoc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
