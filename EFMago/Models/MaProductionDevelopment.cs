using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProductionDevelopment
    {
        public string Computer { get; set; }
        public string UserName { get; set; }
        public string Component { get; set; }
        public string UoM { get; set; }
        public string Variant { get; set; }
        public double? NeededQty { get; set; }
    }
}
