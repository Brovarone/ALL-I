using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPublishingTaxParameters
    {
        public int PublishingTaxParametersId { get; set; }
        public string UsePublishingTax { get; set; }
        public string TaxCode { get; set; }
        public string TaxJournal { get; set; }
        public string PublishingRevenues { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
