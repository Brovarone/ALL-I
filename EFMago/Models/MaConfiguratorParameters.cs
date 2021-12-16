using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConfiguratorParameters
    {
        public int ConfiguratorParametersId { get; set; }
        public string ConfigurationAutoNum { get; set; }
        public string QuestionAutoNum { get; set; }
        public int? LastConfiguration { get; set; }
        public short? ConfigurationMaxChar { get; set; }
        public int? LastQuestion { get; set; }
        public short? QuestionMaxChar { get; set; }
        public int? ExplosionMaxLevel { get; set; }
        public string UseDocPriceListStdItem { get; set; }
        public string PriceListStdItem { get; set; }
        public string UseDocPriceListConfComp { get; set; }
        public string PriceListConfComp { get; set; }
        public string BasePriceListStdItem { get; set; }
        public string BasePriceListConfComp { get; set; }
        public string PricePrompt { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
