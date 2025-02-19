using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImActivation
    {
        public ImActivation()
        {
            ImActivationAppLogins = new HashSet<ImActivationAppLogins>();
            ImActivationLogins = new HashSet<ImActivationLogins>();
        }

        public int ActivationId { get; set; }
        public int? Configuration { get; set; }
        public short? UsersNo { get; set; }
        public string ActivationKey { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public short? AppUserNo { get; set; }
        public string AppData { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ImActivationAppLogins> ImActivationAppLogins { get; set; }
        public virtual ICollection<ImActivationLogins> ImActivationLogins { get; set; }
    }
}
