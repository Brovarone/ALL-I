using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImBudgetRevenues
    {
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public short FiscalYear { get; set; }
        public short Line { get; set; }
        public string JobGroupCode { get; set; }
        public double? RevenuesAmount { get; set; }
        public string RevenuesIndexCode { get; set; }
        public string RevenuesNotes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
