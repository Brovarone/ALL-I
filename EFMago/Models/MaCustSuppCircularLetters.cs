﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustSuppCircularLetters
    {
        public int CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Template { get; set; }
        public string Disabled { get; set; }
        public string Printed { get; set; }
        public DateTime? PrintDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCustSupp CustSuppNavigation { get; set; }
    }
}
