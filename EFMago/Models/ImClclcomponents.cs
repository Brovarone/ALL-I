using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImClclcomponents
    {
        public string ComponentsList { get; set; }
        public string Description { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string ComponentDescription { get; set; }
        public int? CostingType { get; set; }
    }
}
