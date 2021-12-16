using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImEmployees
    {
        public ImEmployees()
        {
            ImEmployeesAnnual = new HashSet<ImEmployeesAnnual>();
            ImEmployeesNotes = new HashSet<ImEmployeesNotes>();
        }

        public string Employee { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public double? OrdinaryCost { get; set; }
        public double? OvertimeCost { get; set; }
        public double? TravelExpenses { get; set; }
        public double? SickLeaveCost { get; set; }
        public double? VacationLeaveCost { get; set; }
        public string FiscalCode { get; set; }
        public string Document1 { get; set; }
        public string Document2 { get; set; }
        public string Document1Type { get; set; }
        public string Document2Type { get; set; }
        public string Disabled { get; set; }
        public double? CustomCost1 { get; set; }
        public double? CustomCost2 { get; set; }
        public double? CustomCost3 { get; set; }
        public double? CustomCost4 { get; set; }
        public string Login { get; set; }
        public string Manager { get; set; }
        public int? TypeAccessJobs { get; set; }
        public string Email { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? Wrstatus { get; set; }
        public int? AppRole { get; set; }
        public string Region { get; set; }

        public virtual ICollection<ImEmployeesAnnual> ImEmployeesAnnual { get; set; }
        public virtual ICollection<ImEmployeesNotes> ImEmployeesNotes { get; set; }
    }
}
