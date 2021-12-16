using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaXbrlparameters
    {
        public int XbrlparametersId { get; set; }
        public string XbrlLinkUrl { get; set; }
        public string XbrlLinkWebService { get; set; }
        public string XbrlOutputPath { get; set; }
        public string ReferenceSchemaCode { get; set; }
        public string XbrlTaxonomy { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string XbrlLinkInfocamereWs { get; set; }
        public string XbrlLinkInfocamereSite { get; set; }
    }
}
