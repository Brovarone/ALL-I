using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEiItadditionalData
    {
        public string FieldName { get; set; }
        public int? Xmlsection { get; set; }
        public string Multiple { get; set; }
        public string Mandatory { get; set; }
        public string DataType { get; set; }
        public short? MinLength { get; set; }
        public short? MaxLength { get; set; }
        public string UpperCase { get; set; }
        public short? MinValue { get; set; }
        public short? MaxValue { get; set; }
        public string Disabled { get; set; }
        public string FromVersion { get; set; }
        public string ToVersion { get; set; }
        public string ViewType { get; set; }
        public string NodeNumber { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
