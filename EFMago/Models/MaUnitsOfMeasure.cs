using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaUnitsOfMeasure
    {
        public MaUnitsOfMeasure()
        {
            MaUnitOfMeasureDetail = new HashSet<MaUnitOfMeasureDetail>();
        }

        public string BaseUoM { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public string Notes { get; set; }
        public Guid? Tbguid { get; set; }
        public string BarcodeSegment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string UoMforEi { get; set; }

        public virtual ICollection<MaUnitOfMeasureDetail> MaUnitOfMeasureDetail { get; set; }
    }
}
