using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConfigurationsQnA
    {
        public string Item { get; set; }
        public string Configuration { get; set; }
        public string QuestionNo { get; set; }
        public short? AnswerNo { get; set; }
        public string DeleteComponent { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaConfigurations MaConfigurations { get; set; }
    }
}
