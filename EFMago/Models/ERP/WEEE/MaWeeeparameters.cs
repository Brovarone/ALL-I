using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWeeeparameters
    {
        public int WeeeparametersId { get; set; }
        public string Description { get; set; }
        public string ShowConfirmDialog { get; set; }
        public string GroupTaxCode { get; set; }
        public string NoContributionOnDocument { get; set; }
        public string TaxCode { get; set; }
        public string Offset { get; set; }
        public Guid? Tbguid { get; set; }
        public string GroupWeeectg { get; set; }
        public string GroupTaxCodeAndWeeectg { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
