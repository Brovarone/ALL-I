using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInventoryJournal
    {
        public short FiscalYear { get; set; }
        public short BalanceYear { get; set; }
        public short MonthBalance { get; set; }
        public string DefinitivelyPrinted { get; set; }
        public DateTime? LastPrintingDate { get; set; }
        public int? NoOfPrintedLines { get; set; }
        public int? NoOfPrintedPages { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
