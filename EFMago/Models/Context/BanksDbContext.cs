using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class BanksDbContext : DbContext
    {
        public BanksDbContext()
        {
        }
        public BanksDbContext(DbContextOptions<BanksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBanks> MaBanks { get; set; }
        public virtual DbSet<MaBanksAccounts> MaBanksAccounts { get; set; }
        public virtual DbSet<MaBanksConditions> MaBanksConditions { get; set; }
        public virtual DbSet<MaBanksFactoringCustomers> MaBanksFactoringCustomers { get; set; }
        public virtual DbSet<MaBanksFactoringPymtTerms> MaBanksFactoringPymtTerms { get; set; }
        public virtual DbSet<MaBanksPeople> MaBanksPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBanks>(entity =>
{
                entity.HasKey(e => new { e.IsAcompanyBank, e.Bank })
                    .HasName("PK_Banks")
                    .IsClustered(false);

                entity.ToTable("MA_Banks");

                entity.HasIndex(e => new { e.Abi, e.Cab })
                    .HasName("MA_Banks3");

                entity.HasIndex(e => new { e.IsAcompanyBank, e.Description })
                    .HasName("MA_Banks2");

                entity.Property(e => e.IsAcompanyBank)
                    .HasColumnName("IsACompanyBank")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Abi)
                    .HasColumnName("ABI")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Abiprefix)
                    .HasColumnName("ABIPrefix")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Agency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BankDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.BillsAndPaymentsExtension)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillsAndPaymentsFolder)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Branch)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cab)
                    .HasColumnName("CAB")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cabprefix)
                    .HasColumnName("CABPrefix")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOrderCbicode)
                    .HasColumnName("CashOrderCBICode")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashOrderResultRequest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cbicode)
                    .HasColumnName("CBICode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Counter)
                    .HasMaxLength(50)
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

                entity.Property(e => e.DebitChargesSeparately)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
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

                entity.Property(e => e.FactoringCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringCurrency)
                    .HasMaxLength(8)
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

                entity.Property(e => e.Identifier)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsForeign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreferredCa)
                    .HasColumnName("PreferredCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SenderCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SenderReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Siacode)
                    .HasColumnName("SIACode")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Signature)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Swift)
                    .HasMaxLength(15)
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

                entity.Property(e => e.UseIso20022)
                    .HasColumnName("UseISO20022")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseValueDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBanksAccounts>(entity =>
{
                entity.HasKey(e => new { e.IsAcompanyBank, e.Bank, e.Ca, e.Presentation })
                    .HasName("PK_BanksAccounts")
                    .IsClustered(false);

                entity.ToTable("MA_BanksAccounts");

                entity.HasIndex(e => new { e.Disabled, e.Blocked, e.Bank, e.Ca, e.Presentation })
                    .HasName("MA_BanksAccounts2");

                entity.Property(e => e.IsAcompanyBank)
                    .HasColumnName("IsACompanyBank")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376260))");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BorrowingRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cacheck)
                    .HasColumnName("CACheck")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cin)
                    .HasColumnName("CIN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCollCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FactoringAdvance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FactoringType).HasDefaultValueSql("((5242880))");

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

                entity.Property(e => e.InternalNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxCreditLimit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostalNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Presented).HasDefaultValueSql("((0))");

                entity.Property(e => e.PymtCash)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.MaBanks)
                    .WithMany(p => p.MaBanksAccounts)
                    .HasForeignKey(d => new { d.IsAcompanyBank, d.Bank })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanksAccou_Banks_00");
            });
            modelBuilder.Entity<MaBanksConditions>(entity =>
{
                entity.HasKey(e => new { e.Bank, e.IsAcompanyBank, e.ConditionCode })
                    .HasName("PK_BanksConditions")
                    .IsClustered(false);

                entity.ToTable("MA_BanksConditions");

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IsAcompanyBank)
                    .HasColumnName("IsACompanyBank")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConditionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Approved)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carteira)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CarteiraOnFile)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyBankId)
                    .HasColumnName("CompanyBankID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Convenio)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.FileLayout).HasDefaultValueSql("((393216))");

                entity.Property(e => e.InterestRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssueSendByBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastFileId)
                    .HasColumnName("LastFileID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxRange).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinRange).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentPlace)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PenalityRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProtestDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.RegisteredCollection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReportNamespace)
                    .HasMaxLength(250)
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
            modelBuilder.Entity<MaBanksFactoringCustomers>(entity =>
{
                entity.HasKey(e => new { e.IsAcompanyBank, e.Bank, e.Customer })
                    .HasName("PK_BanksFactoringCustomers")
                    .IsClustered(false);

                entity.ToTable("MA_BanksFactoringCustomers");

                entity.Property(e => e.IsAcompanyBank)
                    .HasColumnName("IsACompanyBank")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(12)
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

                entity.HasOne(d => d.MaBanks)
                    .WithMany(p => p.MaBanksFactoringCustomers)
                    .HasForeignKey(d => new { d.IsAcompanyBank, d.Bank })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanksFacto_Banks_01");
            });
            modelBuilder.Entity<MaBanksFactoringPymtTerms>(entity =>
{
                entity.HasKey(e => new { e.IsAcompanyBank, e.Bank, e.Payment })
                    .HasName("PK_BanksFactoringPymtTerms")
                    .IsClustered(false);

                entity.ToTable("MA_BanksFactoringPymtTerms");

                entity.Property(e => e.IsAcompanyBank)
                    .HasColumnName("IsACompanyBank")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.MaBanks)
                    .WithMany(p => p.MaBanksFactoringPymtTerms)
                    .HasForeignKey(d => new { d.IsAcompanyBank, d.Bank })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanksFacto_Banks_00");
            });
            modelBuilder.Entity<MaBanksPeople>(entity =>
{
                entity.HasKey(e => new { e.IsAcompanyBank, e.Bank, e.Line })
                    .HasName("PK_BanksPeople")
                    .IsClustered(false);

                entity.ToTable("MA_BanksPeople");

                entity.Property(e => e.IsAcompanyBank)
                    .HasColumnName("IsACompanyBank")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.MaBanks)
                    .WithMany(p => p.MaBanksPeople)
                    .HasForeignKey(d => new { d.IsAcompanyBank, d.Bank })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanksPeopl_Banks_00");
            });
        }
    }
}
