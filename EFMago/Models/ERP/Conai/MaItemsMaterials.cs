using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsMaterials
    {
        public string Item { get; set; }
        public string Material { get; set; }
        public string PrimaryPackage { get; set; }
        public string PackageType { get; set; }
        public string PackageTypeDescription { get; set; }
        public string UoM { get; set; }
        public double? UnitWeight { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
