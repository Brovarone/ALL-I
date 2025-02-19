using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesPeople
    {
        public MaSalesPeople()
        {
            MaSalesPeopleAllowance = new HashSet<MaSalesPeopleAllowance>();
            MaSalesPeopleBalanceFirr = new HashSet<MaSalesPeopleBalanceFirr>();
            MaSalesPeopleBalances = new HashSet<MaSalesPeopleBalances>();
            MaSalesPeoplePartners = new HashSet<MaSalesPeoplePartners>();
        }

        public string Salesperson { get; set; }
        public string Name { get; set; }
        public string IsAnEmployee { get; set; }
        public string Supplier { get; set; }
        public string Enasarco { get; set; }
        public string IsAnAreaManager { get; set; }
        public string AreaManager { get; set; }
        public double? MonthlyFixedAmount { get; set; }
        public string Disabled { get; set; }
        public string OneFirmOnly { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? FiringDate { get; set; }
        public string IsAcompany { get; set; }
        public DateTime? AgencyChangeDate { get; set; }
        public string IsAcorporation { get; set; }
        public string NoCommissionEdit { get; set; }
        public string Policy { get; set; }
        public double? BaseCommission { get; set; }
        public double? BaseAreaMngCommission { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaSalesPeopleAllowance> MaSalesPeopleAllowance { get; set; }
        public virtual ICollection<MaSalesPeopleBalanceFirr> MaSalesPeopleBalanceFirr { get; set; }
        public virtual ICollection<MaSalesPeopleBalances> MaSalesPeopleBalances { get; set; }
        public virtual ICollection<MaSalesPeoplePartners> MaSalesPeoplePartners { get; set; }
    }
}
