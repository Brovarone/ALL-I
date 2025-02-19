using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpIntraDispatches2C
    {
        public Guid SessionGuid { get; set; }
        public int Line { get; set; }
        public int? Progressive { get; set; }
        public string Isocode { get; set; }
        public string TaxId { get; set; }
        public double? Amount { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Cpacode { get; set; }
        public string SupplyType { get; set; }
        public string CollectionType { get; set; }
        public string CountryOfPayment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
