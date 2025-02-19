using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxDeclaration
    {
        public short BalanceYear { get; set; }
        public string Frame { get; set; }
        public short Line { get; set; }
        public string TaxCode { get; set; }
        public int DataType { get; set; }
        public Guid? Tbguid { get; set; }
        public int? ActionOnTotal { get; set; }
        public int? AmountType { get; set; }
        public int? ColumnType { get; set; }
        public short? PrintOrder { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
