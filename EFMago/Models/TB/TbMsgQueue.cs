using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class TbMsgQueue
    {
        public int MsgId { get; set; }
        public int? LotId { get; set; }
        public string Fax { get; set; }
        public string Addressee { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Subject { get; set; }
        public string DocNamespace { get; set; }
        public string DocPrimaryKey { get; set; }
        public string AddresseeNamespace { get; set; }
        public string AddresseePrimaryKey { get; set; }
        public string DocFileName { get; set; }
        public int DocPages { get; set; }
        public int DocSize { get; set; }
        public int DeliveryType { get; set; }
        public int PrintType { get; set; }
        public byte[] DocImage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
