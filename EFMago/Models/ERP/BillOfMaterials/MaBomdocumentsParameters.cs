using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBomdocumentsParameters
    {
        public int BomparametersId { get; set; }
        public int DocumentType { get; set; }
        public string ExpandFirstLevelOnly { get; set; }
        public string GenerateShortInvEntriesSet { get; set; }
        public string RmclearingInvRsn { get; set; }
        public string FpissueToProdInvRsn { get; set; }
        public string RmclearingProdInvRsn { get; set; }
        public string RmreceiptInvRsn { get; set; }
        public string WasteInvRsn { get; set; }
        public string WasteDifferentItemInvRsn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
