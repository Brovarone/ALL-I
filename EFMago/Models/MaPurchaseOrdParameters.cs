using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseOrdParameters
    {
        public int PurchaseOrdParametersId { get; set; }
        public string WarningMaximumStock { get; set; }
        public string DefaultEmptyConfDelivDate { get; set; }
        public string DefaultSupplExpDelivDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
