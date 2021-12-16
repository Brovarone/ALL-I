using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrspedparameters
    {
        public int BrspedparametersId { get; set; }
        public int? DeclarationType { get; set; }
        public int? ActivityType { get; set; }
        public string Accountant { get; set; }
        public string AccountantFiscalCode { get; set; }
        public string AccountantRegisterNo { get; set; }
        public string SpedfilePath { get; set; }
        public string SpedconfigFilePath { get; set; }
        public string IcmsreceiptsCode { get; set; }
        public string IcmsstreceiptsCode { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
