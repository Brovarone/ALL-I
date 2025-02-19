using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaXgateParametersForDocType
    {
        public int DocumentType { get; set; }
        public string Issue { get; set; }
        public string PostAccounting { get; set; }
        public string PostInventory { get; set; }
        public string Printer { get; set; }
        public string Email { get; set; }
        public string PostIntrastat { get; set; }
        public string PostPymntSched { get; set; }
        public string PostReturnToSupplier { get; set; }
        public string PostScrap { get; set; }
        public string PostToReturn { get; set; }
        public string PostInspectionOrder { get; set; }
        public string PostaLite { get; set; }
        public string Archive { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
