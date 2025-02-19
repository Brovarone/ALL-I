using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
        {
        }
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaContactBranches> MaContactBranches { get; set; }
        public virtual DbSet<MaContactNotes> MaContactNotes { get; set; }
        public virtual DbSet<MaContactOrigin> MaContactOrigin { get; set; }
        public virtual DbSet<MaContactSpecification> MaContactSpecification { get; set; }
        public virtual DbSet<MaContacts> MaContacts { get; set; }
        public virtual DbSet<MaContactsPeople> MaContactsPeople { get; set; }
        public virtual DbSet<MaProspectiveSuppBranches> MaProspectiveSuppBranches { get; set; }
        public virtual DbSet<MaProspectiveSuppNotes> MaProspectiveSuppNotes { get; set; }
        public virtual DbSet<MaProspectiveSuppPeople> MaProspectiveSuppPeople { get; set; }
        public virtual DbSet<MaProspectiveSuppliers> MaProspectiveSuppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaContactBranches>(entity =>
{
                entity.HasKey(e => new { e.Contact, e.Branch })
                    .HasName("PK_ContactBranches")
                    .IsClustered(false);

                entity.ToTable("MA_ContactBranches");

                entity.Property(e => e.Contact)
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

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(64)
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

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
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

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.MaContactBranches)
                    .HasForeignKey(d => d.Contact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactBra_Contact_00");
            });
            modelBuilder.Entity<MaContactNotes>(entity =>
{
                entity.HasKey(e => new { e.Contact, e.Line })
                    .HasName("PK_ContactNotes")
                    .IsClustered(false);

                entity.ToTable("MA_ContactNotes");

                entity.Property(e => e.Contact)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CopyCustQuota)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintCustQuota)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowCustQuota)
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

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.MaContactNotes)
                    .HasForeignKey(d => d.Contact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactNot_Contact_00");
            });
            modelBuilder.Entity<MaContactOrigin>(entity =>
{
                entity.HasKey(e => e.ContactOrigin)
                    .HasName("PK_ContactOrigin")
                    .IsClustered(false);

                entity.ToTable("MA_ContactOrigin");

                entity.Property(e => e.ContactOrigin)
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
            modelBuilder.Entity<MaContactSpecification>(entity =>
{
                entity.HasKey(e => e.ContactSpecification)
                    .HasName("PK_ContactSpecification")
                    .IsClustered(false);

                entity.ToTable("MA_ContactSpecification");

                entity.Property(e => e.ContactSpecification)
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
            modelBuilder.Entity<MaContacts>(entity =>
{
                entity.HasKey(e => e.Contact)
                    .HasName("PK_Contacts")
                    .IsClustered(false);

                entity.ToTable("MA_Contacts");

                entity.HasIndex(e => e.Bank)
                    .HasName("MA_Contacts3");

                entity.HasIndex(e => e.TaxIdNumber)
                    .HasName("MA_Contacts2");

                entity.Property(e => e.Contact)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
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

                entity.Property(e => e.Affidabile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CommissionCtg)
                    .HasMaxLength(8)
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

                entity.Property(e => e.ContactDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ContactOrigin)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactsKind).HasDefaultValueSql("((7733248))");

                entity.Property(e => e.ConversionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
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

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptFromTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
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

                entity.Property(e => e.GenRegEntity)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenRegNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAcustSupp)
                    .HasColumnName("IsACustSupp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnEucustSupp)
                    .HasColumnName("IsAnEUCustSupp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.MunicipalityReg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaturalPerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NewTxt)
                    .HasColumnName("NewTXT")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoSendPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
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

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
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

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
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

                entity.Property(e => e.Suframa)
                    .HasColumnName("SUFRAMA")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspendedTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
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
            modelBuilder.Entity<MaContactsPeople>(entity =>
{
                entity.HasKey(e => new { e.Contact, e.Line })
                    .HasName("PK_ContactsPeople")
                    .IsClustered(false);

                entity.ToTable("MA_ContactsPeople");

                entity.Property(e => e.Contact)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SkypeId)
                    .HasColumnName("SkypeID")
                    .HasMaxLength(64)
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

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkingPosition)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.MaContactsPeople)
                    .HasForeignKey(d => d.Contact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_ContPeop_01");
            });
            modelBuilder.Entity<MaProspectiveSuppBranches>(entity =>
{
                entity.HasKey(e => new { e.ProspectiveSupplier, e.Branch })
                    .HasName("PK_ProspectiveSuppBranches")
                    .IsClustered(false);

                entity.ToTable("MA_ProspectiveSuppBranches");

                entity.Property(e => e.ProspectiveSupplier)
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

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(64)
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

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
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

                entity.HasOne(d => d.ProspectiveSupplierNavigation)
                    .WithMany(p => p.MaProspectiveSuppBranches)
                    .HasForeignKey(d => d.ProspectiveSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProSuppBra_ProSupp_00");
            });
            modelBuilder.Entity<MaProspectiveSuppNotes>(entity =>
{
                entity.HasKey(e => new { e.ProspectiveSupplier, e.Line })
                    .HasName("PK_ProspectiveSuppNotes")
                    .IsClustered(false);

                entity.ToTable("MA_ProspectiveSuppNotes");

                entity.Property(e => e.ProspectiveSupplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CopySuppQuota)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintSuppQuota)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowSuppQuota)
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

                entity.HasOne(d => d.ProspectiveSupplierNavigation)
                    .WithMany(p => p.MaProspectiveSuppNotes)
                    .HasForeignKey(d => d.ProspectiveSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProSuppNot_ProSupp_00");
            });
            modelBuilder.Entity<MaProspectiveSuppPeople>(entity =>
{
                entity.HasKey(e => new { e.ProspectiveSupplier, e.Line })
                    .HasName("PK_ProspectiveSuppPeople")
                    .IsClustered(false);

                entity.ToTable("MA_ProspectiveSuppPeople");

                entity.Property(e => e.ProspectiveSupplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SkypeId)
                    .HasColumnName("SkypeID")
                    .HasMaxLength(64)
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

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkingPosition)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ProspectiveSupplierNavigation)
                    .WithMany(p => p.MaProspectiveSuppPeople)
                    .HasForeignKey(d => d.ProspectiveSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_ProSuppPeop_01");
            });
            modelBuilder.Entity<MaProspectiveSuppliers>(entity =>
{
                entity.HasKey(e => e.ProspectiveSupplier)
                    .HasName("PK_ProspectiveSuppliers")
                    .IsClustered(false);

                entity.ToTable("MA_ProspectiveSuppliers");

                entity.HasIndex(e => e.CustSuppBank)
                    .HasName("MA_ProspectiveSuppliers3");

                entity.HasIndex(e => e.TaxIdNumber)
                    .HasName("MA_ProspectiveSuppliers2");

                entity.Property(e => e.ProspectiveSupplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
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

                entity.Property(e => e.Category)
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

                entity.Property(e => e.CompanyRegistrNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactOrigin)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConversionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppBank)
                    .HasMaxLength(11)
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

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptFromTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
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

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GenRegEntity)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenRegNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAcustSupp)
                    .HasColumnName("IsACustSupp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnEucustSupp)
                    .HasColumnName("IsAnEUCustSupp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451840))");

                entity.Property(e => e.MunicipalityReg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaturalPerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoSendPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
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

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProspSuppKind).HasDefaultValueSql("((7733248))");

                entity.Property(e => e.Region)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesOffset)
                    .HasMaxLength(16)
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

                entity.Property(e => e.Suframa)
                    .HasColumnName("SUFRAMA")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspendedTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
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
        }
    }
}
