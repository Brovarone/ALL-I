using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConfigurationsQuestions
    {
        public MaConfigurationsQuestions()
        {
            MaConfigurationsAnswers = new HashSet<MaConfigurationsAnswers>();
        }

        public string QuestionNo { get; set; }
        public string Question { get; set; }
        public string Notes { get; set; }
        public string Deletable { get; set; }
        public string DeletingText { get; set; }
        public string Disabled { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? SubId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaConfigurationsAnswers> MaConfigurationsAnswers { get; set; }
    }
}
