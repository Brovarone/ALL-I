using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEco
    {
        public MaEco()
        {
            MaEcocomponents = new HashSet<MaEcocomponents>();
            MaEcorouting = new HashSet<MaEcorouting>();
        }

        public int Ecoid { get; set; }
        public string Econo { get; set; }
        public string Ecorevision { get; set; }
        public int? Ecostatus { get; set; }
        public DateTime? EcocreationDate { get; set; }
        public DateTime? EcoconfirmationDate { get; set; }
        public string EcoautomaticallyGenerated { get; set; }
        public string Econotes { get; set; }
        public string Bom { get; set; }
        public int? CodeType { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string UsePercQty { get; set; }
        public string Sf { get; set; }
        public string Notes { get; set; }
        public string InProduction { get; set; }
        public int? LastSubId { get; set; }
        public string Configurable { get; set; }
        public string Disabled { get; set; }
        public string SalesDocOnly { get; set; }
        public Guid? Tbguid { get; set; }
        public string DwgDrawing { get; set; }
        public string DwgNotes { get; set; }
        public string DwgPosition { get; set; }
        public string EcoexecutionSignature { get; set; }
        public DateTime? EcoexecutionDate { get; set; }
        public string EcocheckSignature { get; set; }
        public DateTime? EcocheckDate { get; set; }
        public string EcoapprovalSignature { get; set; }
        public DateTime? EcoapprovalDate { get; set; }
        public string EcoimagePath { get; set; }
        public string Variant { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaEcohistory MaEcohistory { get; set; }
        public virtual ICollection<MaEcocomponents> MaEcocomponents { get; set; }
        public virtual ICollection<MaEcorouting> MaEcorouting { get; set; }
    }
}
