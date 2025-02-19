using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConfigurationsAnswers
    {
        public string QuestionNo { get; set; }
        public short AnswerNo { get; set; }
        public string Answer { get; set; }
        public string Notes { get; set; }
        public int? SubId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaConfigurationsQuestions QuestionNoNavigation { get; set; }
    }
}
