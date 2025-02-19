using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConsBalSheets
    {
        public MaConsBalSheets()
        {
            MaConsBalSheetsBalance = new HashSet<MaConsBalSheetsBalance>();
        }

        public string BalanceSchema { get; set; }
        public string Notes { get; set; }
        public string Template { get; set; }
        public string Company { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public DateTime? BalanceDate { get; set; }
        public string Suffix { get; set; }
        public string Sent { get; set; }
        public DateTime? SendingDate { get; set; }
        public string CompanyIdentifier { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaConsBalSheetsBalance> MaConsBalSheetsBalance { get; set; }
    }
}
