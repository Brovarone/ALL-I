using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFactory
    {
        public string Factory { get; set; }
        public string Description { get; set; }
        public string DefaultStorage { get; set; }
        public string DefaultSfstorage { get; set; }
        public string DefaultExtStorage { get; set; }
        public string DefaultExtSfstorage { get; set; }
        public string DefaultScrapStorage { get; set; }
        public string DefaultSecondRateStorage { get; set; }
        public string DefaultExtScrapStorage { get; set; }
        public string DefaultExtSecondRateStorage { get; set; }
        public string PickingStorage { get; set; }
        public string PickingStorageSemifinished { get; set; }
        public string PickingExtStorage { get; set; }
        public string PickingExtStorageSf { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string WasteStorage { get; set; }
        public string WasteDifferentItemStorage { get; set; }
    }
}
