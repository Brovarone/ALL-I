using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaContactsPeople
    {
        public string Contact { get; set; }
        public short Line { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WorkingPosition { get; set; }
        public string Notes { get; set; }
        public string LastName { get; set; }
        public int? MailSendingType { get; set; }
        public string ExternalCode { get; set; }
        public string Branch { get; set; }
        public string SkypeId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaContacts ContactNavigation { get; set; }
    }
}
