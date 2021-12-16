using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrimportDecl
    {
        public int Id { get; set; }
        public int? LastSubId { get; set; }
        public string ImportDeclarationNo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? Importer { get; set; }
        public string ImporterCode { get; set; }
        public string ExporterCode { get; set; }
        public int? IntermediationType { get; set; }
        public string DischargePlace { get; set; }
        public string CustomsState { get; set; }
        public DateTime? CustomsDate { get; set; }
        public double? GrossWeight { get; set; }
        public double? NetWeight { get; set; }
        public string Appearance { get; set; }
        public string ModeOfTransport { get; set; }
        public double? Afrmmtot { get; set; }
        public string InNotaFiscal { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
