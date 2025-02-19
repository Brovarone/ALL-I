using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBillOfMaterials
    {
        public MaBillOfMaterials()
        {
            MaBillOfMaterialsComp = new HashSet<MaBillOfMaterialsComp>();
            MaBillOfMaterialsRouting = new HashSet<MaBillOfMaterialsRouting>();
        }

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
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaBillOfMaterialsDrawings MaBillOfMaterialsDrawings { get; set; }
        public virtual ICollection<MaBillOfMaterialsComp> MaBillOfMaterialsComp { get; set; }
        public virtual ICollection<MaBillOfMaterialsRouting> MaBillOfMaterialsRouting { get; set; }
    }
}
