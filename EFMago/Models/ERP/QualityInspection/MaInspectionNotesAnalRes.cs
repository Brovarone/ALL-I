using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInspectionNotesAnalRes
    {
        public int InspectionNotesId { get; set; }
        public short Line { get; set; }
        public int SubId { get; set; }
        public short? ParameterLine { get; set; }
        public string Parameter { get; set; }
        public double? NumericResult { get; set; }
        public string Result { get; set; }
        public DateTime? CompilationDate { get; set; }
        public short? AnalysisArea { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
