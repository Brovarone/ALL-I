using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxSettlementSendings
    {
        public int TaxSettlementSendingId { get; set; }
        public int? SendingStatus { get; set; }
        public short? BalanceYear { get; set; }
        public short? Quarter { get; set; }
        public DateTime? SendingDate { get; set; }
        public string TelProtocol { get; set; }
        public string DocProtocol { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
