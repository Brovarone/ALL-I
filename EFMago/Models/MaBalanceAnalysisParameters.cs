using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBalanceAnalysisParameters
    {
        public int BalanceAnalysisParameterId { get; set; }
        public string AssetsSchemaCode { get; set; }
        public string LiabilitiesSchemaCode { get; set; }
        public string ProfitLossSchemaCode { get; set; }
        public string UseLineNoCol { get; set; }
        public string LossSchemaCode { get; set; }
        public string CapitalSchemaCode { get; set; }
        public string CashReceivablesSchemaCode { get; set; }
        public string CashPayablesSchemaCode { get; set; }
        public string BeOoutputPath { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
