using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsTechDataDefinition
    {
        public string CommodityCtg { get; set; }
        public string Name { get; set; }
        public int? LineType { get; set; }
        public string Deletable { get; set; }
        public string Mandatory { get; set; }
        public double? MinNumber { get; set; }
        public double? MaxNumber { get; set; }
        public string MinString { get; set; }
        public string MaxString { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public double? NumberDefault { get; set; }
        public string StringDefault { get; set; }
        public DateTime? DateDefault { get; set; }
        public string BoolDefault { get; set; }
        public string PathDefault { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
