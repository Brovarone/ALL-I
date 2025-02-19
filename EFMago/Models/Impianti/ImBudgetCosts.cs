using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImBudgetCosts
    {
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public short FiscalYear { get; set; }
        public short Line { get; set; }
        public int Type { get; set; }
        public string JobGroupCode { get; set; }
        public double? CostsAmount { get; set; }
        public string CostsIndexCode { get; set; }
        public string CostsNotes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
