using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSmartCodes
    {
        public string Root { get; set; }
        public string Description { get; set; }
        public string SeparatorCode { get; set; }
        public short? DescriptionSeparator { get; set; }
        public string DescriptionDelimiter { get; set; }
        public short? Length { get; set; }
        public string SegmentSeparator { get; set; }
        public short? NoOfSegments { get; set; }
        public string BaseUoM { get; set; }
        public string HomogeneousCtg { get; set; }
        public string CommodityCtg { get; set; }
        public string TaxCode { get; set; }
        public string SaleOffset { get; set; }
        public string PurchaseOffset { get; set; }
        public string CalculatePrice { get; set; }
        public string CalculateWeight { get; set; }
        public double? Price { get; set; }
        public double? Weight { get; set; }
        public string Notes { get; set; }
        public string GenerateComparableUoM { get; set; }
        public string ComparableUoM { get; set; }
        public double? FactorValue { get; set; }
        public string FactorDescription { get; set; }
        public int? FactorNo { get; set; }
        public string SetConversionFactor { get; set; }
        public string ReferenceUoMcalculatedValue { get; set; }
        public string ConvertCoefficientsInUoM { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string Disabled { get; set; }
    }
}
