using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesPeoplePartners
    {
        public string Salesperson { get; set; }
        public string IdNumber { get; set; }
        public string LastName { get; set; }
        public string FiscalCode { get; set; }
        public double? Quota { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSalesPeople SalespersonNavigation { get; set; }
    }
}
