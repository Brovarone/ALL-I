﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConsolidTemplates
    {
        public MaConsolidTemplates()
        {
            MaConsolidTemplatesDetail = new HashSet<MaConsolidTemplatesDetail>();
        }

        public string Template { get; set; }
        public string Description { get; set; }
        public string Suffix { get; set; }
        public string CompanyIdentifier { get; set; }
        public string Mask { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaConsolidTemplatesDetail> MaConsolidTemplatesDetail { get; set; }
    }
}
