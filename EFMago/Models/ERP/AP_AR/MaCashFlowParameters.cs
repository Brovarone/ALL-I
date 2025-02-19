using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCashFlowParameters
    {
        public int CashFlowParametersId { get; set; }
        public string NegAllowancePymtCash { get; set; }
        public string NegAllowancePymtAccount { get; set; }
        public string PosAllowancePymtCash { get; set; }
        public string PosAllowancePymtAccount { get; set; }
        public string NegRoundingPymtAccount { get; set; }
        public string PosRoundingPymtAccount { get; set; }
        public string CustAdvancePymtCash { get; set; }
        public string CustAdvancePymtAccount { get; set; }
        public string SuppAdvancePymtCash { get; set; }
        public string SuppAdvancePymtAccount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
