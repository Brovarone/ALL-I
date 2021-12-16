using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImRlayoutsDetails
    {
        public string RecordLayout { get; set; }
        public short Line { get; set; }
        public string Description { get; set; }
        public int? FieldType { get; set; }
        public string Separator { get; set; }
        public short? Decimals { get; set; }
        public short? Position { get; set; }
        public short? Length { get; set; }
        public int? TargetField { get; set; }
        public string ConvertToBaseCurr { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImRecordLayouts RecordLayoutNavigation { get; set; }
    }
}
