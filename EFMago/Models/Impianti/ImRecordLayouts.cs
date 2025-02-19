using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImRecordLayouts
    {
        public ImRecordLayouts()
        {
            ImRlayoutsDetails = new HashSet<ImRlayoutsDetails>();
            ImRlayoutsPrefixReplacing = new HashSet<ImRlayoutsPrefixReplacing>();
            ImRlayoutsProducers = new HashSet<ImRlayoutsProducers>();
            ImRlayoutsWeee = new HashSet<ImRlayoutsWeee>();
        }

        public string RecordLayout { get; set; }
        public string Description { get; set; }
        public string FirstLineContainsHeaders { get; set; }
        public string ItemPrefix { get; set; }
        public int? BarcodeType { get; set; }
        public string ApplyItemSupplierPrefix { get; set; }
        public string ReplacePrefix { get; set; }
        public string Currency { get; set; }
        public string ProducersAreExcluded { get; set; }
        public string IsWeeerlayout { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<ImRlayoutsDetails> ImRlayoutsDetails { get; set; }
        public virtual ICollection<ImRlayoutsPrefixReplacing> ImRlayoutsPrefixReplacing { get; set; }
        public virtual ICollection<ImRlayoutsProducers> ImRlayoutsProducers { get; set; }
        public virtual ICollection<ImRlayoutsWeee> ImRlayoutsWeee { get; set; }
    }
}
