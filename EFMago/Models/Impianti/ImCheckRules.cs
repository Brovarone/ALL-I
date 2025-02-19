using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImCheckRules
    {
        public ImCheckRules()
        {
            ImCheckGroupRule = new HashSet<ImCheckGroupRule>();
            ImCheckRuleParameter = new HashSet<ImCheckRuleParameter>();
            ImCheckRulesRefDocKeys = new HashSet<ImCheckRulesRefDocKeys>();
        }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CheckType { get; set; }
        public string CheckSelectQuery { get; set; }
        public string ShortMessage { get; set; }
        public string RefDisplayField { get; set; }
        public string RefDocument { get; set; }
        public string Note { get; set; }
        public string Disabled { get; set; }
        public string IsOwner { get; set; }
        public string Deleted { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImCheckRulesMessage ImCheckRulesMessage { get; set; }
        public virtual ICollection<ImCheckGroupRule> ImCheckGroupRule { get; set; }
        public virtual ICollection<ImCheckRuleParameter> ImCheckRuleParameter { get; set; }
        public virtual ICollection<ImCheckRulesRefDocKeys> ImCheckRulesRefDocKeys { get; set; }
    }
}
