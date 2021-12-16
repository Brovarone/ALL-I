using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class LtenoteUtente
    {
        public string CodiceUtente { get; set; }
        public short Riga { get; set; }
        public string Annotazione { get; set; }
    }
}
