using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMocomponentsStepsQty
    {
        public int Moid { get; set; }
        public short MocomponentsLineNumber { get; set; }
        public short RtgStep { get; set; }
        public double? EnteredQuantity { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaMocomponents Mo { get; set; }
    }
}
