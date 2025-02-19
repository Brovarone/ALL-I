using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaChartOfAccountParameters
    {
        public int ChartOfAccountParametersId { get; set; }
        public short? AccountLength { get; set; }
        public short? LedegerLength { get; set; }
        public string VariableLength { get; set; }
        public short? NoOfSegments { get; set; }
        public string Segment1 { get; set; }
        public short? Segment1Length { get; set; }
        public string Segment2 { get; set; }
        public short? Segment2Length { get; set; }
        public string Segment3 { get; set; }
        public short? Segment3Length { get; set; }
        public string Segment4 { get; set; }
        public short? Segment4Length { get; set; }
        public string Segment5 { get; set; }
        public short? Segment5Length { get; set; }
        public string Segment6 { get; set; }
        public short? Segment6Length { get; set; }
        public string Segment7 { get; set; }
        public short? Segment7Length { get; set; }
        public short? MaxLengthSegment { get; set; }
        public string SummaryAccCheck { get; set; }
        public string SaleLedgerTypeFilter { get; set; }
        public string PurchLedgerTypeFilter { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
