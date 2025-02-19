using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImItemsSpoolWeee
    {
        public int ImportId { get; set; }
        public string Supplier { get; set; }
        public string Item { get; set; }
        public short Line { get; set; }
        public string TaxType { get; set; }
        public string Consortium { get; set; }
        public string FeeCode { get; set; }
        public string FeeDescription { get; set; }
        public short? FeeQty { get; set; }
        public double? FeeUnitAmount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImItemsSpool ImItemsSpool { get; set; }
    }
}
