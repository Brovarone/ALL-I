using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CustomersSuppliersDbContext : DbContext
    {
        public CustomersSuppliersDbContext()
        {
        }
        public CustomersSuppliersDbContext(DbContextOptions<CustomersSuppliersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCircularLetterTemplates> MaCircularLetterTemplates { get; set; }
        public virtual DbSet<MaCustSupp> MaCustSupp { get; set; }
        public virtual DbSet<MaCustSuppBalances> MaCustSuppBalances { get; set; }
        public virtual DbSet<MaCustSuppBranches> MaCustSuppBranches { get; set; }
        public virtual DbSet<MaCustSuppBudget> MaCustSuppBudget { get; set; }
        public virtual DbSet<MaCustSuppCircularLetters> MaCustSuppCircularLetters { get; set; }
        public virtual DbSet<MaCustSuppCustomerOptions> MaCustSuppCustomerOptions { get; set; }
        public virtual DbSet<MaCustSuppForm> MaCustSuppForm { get; set; }
        public virtual DbSet<MaCustSuppFormCategory> MaCustSuppFormCategory { get; set; }
        public virtual DbSet<MaCustSuppNaturalPerson> MaCustSuppNaturalPerson { get; set; }
        public virtual DbSet<MaCustSuppNotes> MaCustSuppNotes { get; set; }
        public virtual DbSet<MaCustSuppOutstandings> MaCustSuppOutstandings { get; set; }
        public virtual DbSet<MaCustSuppParameters> MaCustSuppParameters { get; set; }
        public virtual DbSet<MaCustSuppPeople> MaCustSuppPeople { get; set; }
        public virtual DbSet<MaCustSuppSupplierOptions> MaCustSuppSupplierOptions { get; set; }
        public virtual DbSet<MaCustomerClassification> MaCustomerClassification { get; set; }
        public virtual DbSet<MaCustomerCtg> MaCustomerCtg { get; set; }
        public virtual DbSet<MaCustomerSpecification> MaCustomerSpecification { get; set; }
        public virtual DbSet<MaRosuspendedTax> MaRosuspendedTax { get; set; }
        public virtual DbSet<MaSupplierClassification> MaSupplierClassification { get; set; }
        public virtual DbSet<MaSupplierCtg> MaSupplierCtg { get; set; }
        public virtual DbSet<MaSupplierSpecification> MaSupplierSpecification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCircularLetterTemplates>(entity =>
{
                entity.HasKey(e => e.Template)
                    .HasName("PK_CircularLetterTemplates")
                    .IsClustered(false);

                entity.ToTable("MA_CircularLetterTemplates");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FileNamespace)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PldeliveryType)
                    .HasColumnName("PLDeliveryType")
                    .HasDefaultValueSql("((2147352576))");

                entity.Property(e => e.PlprintType)
                    .HasColumnName("PLPrintType")
                    .HasDefaultValueSql("((2147287040))");

                entity.Property(e => e.PrintAuthSect)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReportNamespace)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Subject)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaCustSupp>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp })
                    .HasName("PK_CustSupp")
                    .IsClustered(false);

                entity.ToTable("MA_CustSupp");

                entity.HasIndex(e => e.CustSuppBank)
                    .HasName("MA_CustSupp6");

                entity.HasIndex(e => e.TaxIdNumber)
                    .HasName("MA_CustSupp5");

                entity.HasIndex(e => new { e.CustSuppType, e.CompanyName })
                    .HasName("MA_CustSupp2");

                entity.HasIndex(e => new { e.CustSuppType, e.FiscalCode })
                    .HasName("MA_CustSupp4");

                entity.HasIndex(e => new { e.CustSuppType, e.TaxIdNumber })
                    .HasName("MA_CustSupp3");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdministrationReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AllcopiaCartacea)
                    .HasColumnName("ALLCopiaCartacea")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AswStandard).HasDefaultValueSql("((12582912))");

                entity.Property(e => e.BlackListCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cacheck)
                    .HasColumnName("CACheck")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cbicode)
                    .HasColumnName("CBICode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CertifiedEmail)
                    .HasColumnName("CertifiedEMail")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChambOfCommCounty)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChambOfCommRegistrNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cin)
                    .HasColumnName("CIN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyCa)
                    .HasColumnName("CompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyRegistrNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppKind).HasDefaultValueSql("((7733248))");

                entity.Property(e => e.CustomerCompanyCa)
                    .HasColumnName("CustomerCompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DdcustSupp)
                    .HasColumnName("DDCustSupp")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.District)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentSendingType).HasDefaultValueSql("((11337728))");

                entity.Property(e => e.Draft)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EicertifiedEmail)
                    .HasColumnName("EICertifiedEMail")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EitypeCodeItem)
                    .HasColumnName("EITypeCodeItem")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EitypeCodeItemBarcode)
                    .HasColumnName("EITypeCodeItemBarcode")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EitypeCodeItemCustomer)
                    .HasColumnName("EITypeCodeItemCustomer")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EiunitValue)
                    .HasColumnName("EIUnitValue")
                    .HasDefaultValueSql("((24903680))");

                entity.Property(e => e.ElectronicInvoicing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Eoricode)
                    .HasColumnName("EORICode")
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringCa)
                    .HasColumnName("FactoringCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FantasyName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FdcompanyName)
                    .HasColumnName("FDCompanyName")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fdeoricode)
                    .HasColumnName("FDEORICode")
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FdfiscalCode)
                    .HasColumnName("FDFiscalCode")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FdfiscalCodeId)
                    .HasColumnName("FDFiscalCodeID")
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FdisocountryCode)
                    .HasColumnName("FDISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FdlastName)
                    .HasColumnName("FDLastName")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fdname)
                    .HasColumnName("FDName")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FdnaturalPerson)
                    .HasColumnName("FDNaturalPerson")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FdtitleCode)
                    .HasColumnName("FDTitleCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FedStateReg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FederalState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalRegime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenRegEntity)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenRegNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IbanisManual)
                    .HasColumnName("IBANIsManual")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ImmediateLikeAccompanying)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InCurrency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InLiquidation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InTaxLists)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InsertionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipacode)
                    .HasColumnName("IPACode")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAnEucustSupp)
                    .HasColumnName("IsAnEUCustSupp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsCustoms)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsDummy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LeasingLetter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LinkedCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451841))");

                entity.Property(e => e.MunicipalityReg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaturalPerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoBlackList)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoSendPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoTaxComm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OldCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmniasubAccount)
                    .HasColumnName("OMNIASubAccount")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentPeriShablesOver60)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentPeriShablesWithin60)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PermanentBranchCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintedInKepyo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PrivacyStatement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrivacyStatementPrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Profession)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PublicSector)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Region)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegisterReceivedEi)
                    .HasColumnName("RegisterReceivedEI")
                    .HasDefaultValueSql("((20905986))");

                entity.Property(e => e.SendByCertifiedEmail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Siacode)
                    .HasColumnName("SIACode")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SkypeId)
                    .HasColumnName("SkypeID")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SplitTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubmissionExcluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Suframa)
                    .HasColumnName("SUFRAMA")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxOffice)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxpayerType).HasDefaultValueSql("((30212096))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telex)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsedForSummaryDocuments)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WorkingPosition)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkingTime)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaCustSuppBalances>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth, e.Nature, e.Currency })
                    .HasName("PK_CustSuppBalances")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppBalances");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppBalances)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppBa_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppBranches>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Branch })
                    .HasName("PK_CustSuppBranches")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppBranches");

                entity.HasIndex(e => e.TaxIdNumber)
                    .HasName("MA_CustSuppBranches2");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdministrationReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.District)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EishipNumberData)
                    .HasColumnName("EIShipNumberData")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EishipTextData)
                    .HasColumnName("EIShipTextData")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EishipTypeData)
                    .HasColumnName("EIShipTypeData")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FederalState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipacode)
                    .HasColumnName("IPACode")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451841))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Region)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Siacode)
                    .HasColumnName("SIACode")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SkypeId)
                    .HasColumnName("SkypeID")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxOffice)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telex)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkingTime)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppBranches)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppBr_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppBudget>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth })
                    .HasName("PK_CustSuppBudget")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppBudget");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActualCreditNotesAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebitNotesAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualOrdered).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualTurnover).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedBudget).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.TurnoverBudget).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppBudget)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppBu_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppCircularLetters>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Template })
                    .HasName("PK_CustSuppCircularLetters")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppCircularLetters");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppCircularLetters)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppCi_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppCustomerOptions>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.Customer })
                    .HasName("PK_CustSuppCustomerOptions")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppCustomerOptions");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AllocationArea)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOnDeliveryLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.CashOrderCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesPercOnTotAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.CommissionCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Contract)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustomerClassification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCollectionCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DebitFreeSamplesTaxAmount).HasDefaultValueSql("((3276802))");

                entity.Property(e => e.DebitStampCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeclarationOfIntentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DeclarationOfIntentDueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DeclarationOfIntentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeclarationOfIntentNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeclarationOfIntentOurNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirectAllocation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromWeee)
                    .HasColumnName("ExcludedFromWEEE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExemptFromTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FreeOfChargeLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.GoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupBills)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GroupCostAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupItems)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupOrders)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicingCustomer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingGroup)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAprivatePerson)
                    .HasColumnName("IsAPrivatePerson")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastDocTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotOverbook)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotSelection).HasDefaultValueSql("((8454147))");

                entity.Property(e => e.MaxOrderValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxOrderValueCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaxOrderValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MaxOrderedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxOrderedValueCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaxOrderedValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MaximumCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumCreditCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.NoCarrierCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfMaxLevelReqForPymt).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrintDueDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotUseTd25)
                    .HasColumnName("NotUseTD25")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneDnperOrder)
                    .HasColumnName("OneDNPerOrder")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneDocumentPerPl)
                    .HasColumnName("OneDocumentPerPL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneInvoicePerDn)
                    .HasColumnName("OneInvoicePerDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneInvoicePerOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneReturnFromCustomerPerCn)
                    .HasColumnName("OneReturnFromCustomerPerCN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OpenedAdmCases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OpenedAdmCasesAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.PackCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PasplitPayment)
                    .HasColumnName("PASplitPayment")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PenalityPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.PublicAuthority)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReferencesPrintType).HasDefaultValueSql("((524293))");

                entity.Property(e => e.ReqForPymtLastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ReqForPymtLastLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReqForPymtThreshold).HasDefaultValueSql("((0))");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShowPricesOnDn)
                    .HasColumnName("ShowPricesOnDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuspendedTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TssendObjection)
                    .HasColumnName("TSSendObjection")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseReqForPymt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VirtualStampFulfilled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTaxManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.MaCustSuppCustomerOptions)
                    .HasForeignKey<MaCustSuppCustomerOptions>(d => new { d.CustSuppType, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppCu_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppForm>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.DocumentNamespace })
                    .HasName("PK_CustSuppForm")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppForm");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentNamespace)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReportNamespace)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaCustSuppFormCategory>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.Category, e.DocumentNamespace })
                    .HasName("PK_CustSuppFormCategory")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppFormCategory");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentNamespace)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReportNamespace)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaCustSuppNaturalPerson>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp })
                    .HasName("PK_CustSuppNaturalPerson")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppNaturalPerson");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CityOfBirth)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfBirth)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FeeTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ForfeitRegime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Form770Letter)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Gender).HasDefaultValueSql("((2097152))");

                entity.Property(e => e.Inpsaccount)
                    .HasColumnName("INPSAccount")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Professional)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithOne(p => p.MaCustSuppNaturalPerson)
                    .HasForeignKey<MaCustSuppNaturalPerson>(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppNa_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppNotes>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Line })
                    .HasName("PK_CustSuppNotes")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppNotes");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AccompanyingInvoices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BillOfLading)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CopyInPurchases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CopyInSales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrAccInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrReceipt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreditNote)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustQuota)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DebitNote)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Dn)
                    .HasColumnName("DN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Einvoice)
                    .HasColumnName("EInvoice")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceForAdv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ncreceipt)
                    .HasColumnName("NCReceipt")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingList)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Proforma)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchCorrInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchInvForAdv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Receipt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RetCust)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RetSupp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowInAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowInPurchases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowInPureAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowInSales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubcontrBillOfLading)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubcontrDeliveryNote)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubcontrPurchOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuppQuota)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppNotes)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppNo_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppOutstandings>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.FiscalYear })
                    .HasName("PK_CustSuppOutstandings")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppOutstandings");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfOutstandings).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutstandingsTotAmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppOutstandings)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppOu_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppParameters>(entity =>
{
                entity.HasKey(e => e.CustSuppParametersId)
                    .HasName("PK_CustSuppParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppParameters");

                entity.Property(e => e.CustSuppParametersId).ValueGeneratedNever();

                entity.Property(e => e.AutomaticPrefix)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BankComboMaxItems).HasDefaultValueSql("((300))");

                entity.Property(e => e.CityComboMaxItems).HasDefaultValueSql("((300))");

                entity.Property(e => e.ContactsAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContactsAutomaticPrefix)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContactsMaxChars).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustDocumentSendingType).HasDefaultValueSql("((11337728))");

                entity.Property(e => e.CustMailSendingType).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.CustPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppDraftDefault)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustSuppDraftType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.CustSuppMaxChars).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EucustomerTaxCode)
                    .HasColumnName("EUCustomerTaxCode")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastContact).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCustomer).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastProspSupp).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSupplier).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrefixWithSiteCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProspSuppAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuppDocumentSendingType).HasDefaultValueSql("((11337728))");

                entity.Property(e => e.SuppMailSendingType).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.SuppPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierAutonum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxIdNumberLinkUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.UseCityComplete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaCustSuppPeople>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Line })
                    .HasName("PK_CustSuppPeople")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppPeople");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AccompanyingInvoices).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.AllDocuments).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionAccInvoice).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.CorrectionInvoice).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.CorrectionReceipt).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.CreditNote).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.CustomerQuotation).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.DebitNote).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.DeliveryNote).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Invoice).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.InvoiceForAdvance).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LegalRepresentative)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NonCollectedReceipt).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingList).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.ProformaInvoice).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.PurchaseOrder).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Receipt).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.ReturnFromCustomer).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.ReturnToSupplier).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.SaleOrder).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.SkypeId)
                    .HasColumnName("SkypeID")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcontrDeliveryNote).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.SupplierQuotation).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telex)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkingPosition)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppPeople)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppPe_CustSupp_01");
            });
            modelBuilder.Entity<MaCustSuppSupplierOptions>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.Supplier })
                    .HasName("PK_CustSuppSupplierOptions")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppSupplierOptions");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlockPayments)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOnDeliveryLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.CashOnDeliveryLevelDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesType).HasDefaultValueSql("((25559040))");

                entity.Property(e => e.CreditFreeSamplesTaxAmount).HasDefaultValueSql("((3276802))");

                entity.Property(e => e.CustomTariff)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptFromTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupCollectionCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupPymtOrders)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GroupStampCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastDocTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaximumCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumCreditCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.NoDngeneration)
                    .HasColumnName("NoDNGeneration")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferencesPrintType).HasDefaultValueSql("((524293))");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowPricesOnDn)
                    .HasColumnName("ShowPricesOnDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SupplierClassification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierType).HasDefaultValueSql("((7733248))");

                entity.Property(e => e.SuspendedTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.MaCustSupp)
                    .WithOne(p => p.MaCustSuppSupplierOptions)
                    .HasForeignKey<MaCustSuppSupplierOptions>(d => new { d.CustSuppType, d.Supplier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppSu_CustSupp_00");
            });
            modelBuilder.Entity<MaCustomerClassification>(entity =>
{
                entity.HasKey(e => e.CustomerClassification)
                    .HasName("PK_CustomerClassification")
                    .IsClustered(false);

                entity.ToTable("MA_CustomerClassification");

                entity.Property(e => e.CustomerClassification)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaCustomerCtg>(entity =>
{
                entity.HasKey(e => e.Category)
                    .HasName("PK_CustomerCtg")
                    .IsClustered(false);

                entity.ToTable("MA_CustomerCtg");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_CustomerCtg2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaCustomerSpecification>(entity =>
{
                entity.HasKey(e => e.CustomerSpecification)
                    .HasName("PK_CustomerSpecification")
                    .IsClustered(false);

                entity.ToTable("MA_CustomerSpecification");

                entity.Property(e => e.CustomerSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaRosuspendedTax>(entity =>
{
                entity.HasKey(e => e.SuspendedId)
                    .HasName("PK_ROSuspendedTax")
                    .IsClustered(false);

                entity.ToTable("MA_ROSuspendedTax");

                entity.Property(e => e.SuspendedId)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.UpdateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaSupplierClassification>(entity =>
{
                entity.HasKey(e => e.SupplierClassification)
                    .HasName("PK_SupplierClassification")
                    .IsClustered(false);

                entity.ToTable("MA_SupplierClassification");

                entity.Property(e => e.SupplierClassification)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaSupplierCtg>(entity =>
{
                entity.HasKey(e => e.Category)
                    .HasName("PK_SupplierCtg")
                    .IsClustered(false);

                entity.ToTable("MA_SupplierCtg");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_SupplierCtg2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaSupplierSpecification>(entity =>
{
                entity.HasKey(e => e.SupplierSpecification)
                    .HasName("PK_SupplierSpecification")
                    .IsClustered(false);

                entity.ToTable("MA_SupplierSpecification");

                entity.Property(e => e.SupplierSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
        }
    }
}
