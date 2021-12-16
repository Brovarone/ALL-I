using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSpecificationsItems
    {
        public string Specification { get; set; }
        public string Item { get; set; }
        public string UoM { get; set; }
        public string ParentItem { get; set; }
        public double? Price { get; set; }
        public int? Time { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int Line { get; set; }
        public short Priority { get; set; }
        public string TreeData { get; set; }
        public short? Level { get; set; }
        public int? ParentLine { get; set; }
        public int? LineType { get; set; }
        public string ClforItem { get; set; }
        public double? Qty { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSpecifications SpecificationNavigation { get; set; }
    }
}
