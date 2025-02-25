﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImCheckGroups
    {
        public ImCheckGroups()
        {
            ImCheckGroupParameters = new HashSet<ImCheckGroupParameters>();
            ImCheckGroupRule = new HashSet<ImCheckGroupRule>();
        }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Disabled { get; set; }
        public string IsOwner { get; set; }
        public string Deleted { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<ImCheckGroupParameters> ImCheckGroupParameters { get; set; }
        public virtual ICollection<ImCheckGroupRule> ImCheckGroupRule { get; set; }
    }
}
