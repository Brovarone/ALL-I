using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class MultiCompanyBalancesDbContext : DbContext
    {
        public MultiCompanyBalancesDbContext()
        {
        }
        public MultiCompanyBalancesDbContext(DbContextOptions<MultiCompanyBalancesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCompanyGroupNotes> MaCompanyGroupNotes { get; set; }
        public virtual DbSet<MaCompanyGroupPeople> MaCompanyGroupPeople { get; set; }
        public virtual DbSet<MaCompanyGroups> MaCompanyGroups { get; set; }
        public virtual DbSet<MaConsBalSheetParameters> MaConsBalSheetParameters { get; set; }
        public virtual DbSet<MaConsBalSheetParametersAcc> MaConsBalSheetParametersAcc { get; set; }
        public virtual DbSet<MaConsBalSheets> MaConsBalSheets { get; set; }
        public virtual DbSet<MaConsBalSheetsBalance> MaConsBalSheetsBalance { get; set; }
        public virtual DbSet<MaConsolidTemplates> MaConsolidTemplates { get; set; }
        public virtual DbSet<MaConsolidTemplatesDetail> MaConsolidTemplatesDetail { get; set; }
        public virtual DbSet<MaOwnedCompanies> MaOwnedCompanies { get; set; }
        public virtual DbSet<MaOwnedCompaniesBalances> MaOwnedCompaniesBalances { get; set; }
        public virtual DbSet<MaOwnedCompaniesJe> MaOwnedCompaniesJe { get; set; }
        public virtual DbSet<MaOwnedCompaniesSendings> MaOwnedCompaniesSendings { get; set; }
        public virtual DbSet<MaOwnerCompanies> MaOwnerCompanies { get; set; }
        public virtual DbSet<MaOwnerCompaniesBalances> MaOwnerCompaniesBalances { get; set; }
        public virtual DbSet<MaOwnerCompaniesSendings> MaOwnerCompaniesSendings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCompanyGroupNotes>(entity =>
{
                entity.HasKey(e => new { e.Company, e.Line })
                    .HasName("PK_CompanyGroupNotes")
                    .IsClustered(false);

                entity.ToTable("MA_CompanyGroupNotes");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PublicCompany)
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

                entity.Property(e => e.UseInBalanceSheetNotes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaCompanyGroupNotes)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyGro_CompanyGro_00");
            });
            modelBuilder.Entity<MaCompanyGroupPeople>(entity =>
{
                entity.HasKey(e => new { e.Company, e.Line })
                    .HasName("PK_CompanyGroupPeople")
                    .IsClustered(false);

                entity.ToTable("MA_CompanyGroupPeople");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CityOfBirth)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfBirth)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Gender).HasDefaultValueSql("((2097152))");

                entity.Property(e => e.InternalPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qualification)
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

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaCompanyGroupPeople)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyGro_CompanyGro_01");
            });
            modelBuilder.Entity<MaCompanyGroups>(entity =>
{
                entity.HasKey(e => e.Company)
                    .HasName("PK_CompanyGroups")
                    .IsClustered(false);

                entity.ToTable("MA_CompanyGroups");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BusinessKind)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyName)
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

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.District)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FederalState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternetAddress)
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

                entity.Property(e => e.StatedCapital).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaConsBalSheetParameters>(entity =>
{
                entity.HasKey(e => e.ConsBalSheetParametersId)
                    .HasName("PK_ConsBalSheetParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ConsBalSheetParameters");

                entity.Property(e => e.ConsBalSheetParametersId).ValueGeneratedNever();

                entity.Property(e => e.ConsolidationAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsolidationAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsolidationAccount)
                    .HasMaxLength(16)
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
            modelBuilder.Entity<MaConsBalSheetParametersAcc>(entity =>
{
                entity.HasKey(e => new { e.ConsBalSheetParametersId, e.Line })
                    .HasName("PK_ConsBalSheetParametersAcc")
                    .IsClustered(false);

                entity.ToTable("MA_ConsBalSheetParametersAcc");

                entity.Property(e => e.ConsolidationAccount)
                    .HasMaxLength(16)
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

                entity.HasOne(d => d.ConsBalSheetParameters)
                    .WithMany(p => p.MaConsBalSheetParametersAcc)
                    .HasForeignKey(d => d.ConsBalSheetParametersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsBalShe_ConsBalShe_00");
            });
            modelBuilder.Entity<MaConsBalSheets>(entity =>
{
                entity.HasKey(e => e.BalanceSchema)
                    .HasName("PK_ConsBalSheets")
                    .IsClustered(false);

                entity.ToTable("MA_ConsBalSheets");

                entity.Property(e => e.BalanceSchema)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyIdentifier)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Sent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(8)
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

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaConsBalSheetsBalance>(entity =>
{
                entity.HasKey(e => new { e.BalanceSchema, e.ExternalCode, e.Line })
                    .HasName("PK_ConsBalSheetsBalance")
                    .IsClustered(false);

                entity.ToTable("MA_ConsBalSheetsBalance");

                entity.Property(e => e.BalanceSchema)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.BalanceSchemaNavigation)
                    .WithMany(p => p.MaConsBalSheetsBalance)
                    .HasForeignKey(d => d.BalanceSchema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsBalShe_ConsBalShe_01");
            });
            modelBuilder.Entity<MaConsolidTemplates>(entity =>
{
                entity.HasKey(e => e.Template)
                    .HasName("PK_ConsolidTemplates")
                    .IsClustered(false);

                entity.ToTable("MA_ConsolidTemplates");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyIdentifier)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mask)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(8)
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
            modelBuilder.Entity<MaConsolidTemplatesDetail>(entity =>
{
                entity.HasKey(e => new { e.Template, e.Line })
                    .HasName("PK_ConsolidTemplatesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_ConsolidTemplatesDetail");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccountGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCredit).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IgnoreDifferentBalanceSign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IncidencePerc).HasDefaultValueSql("((100))");

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

                entity.HasOne(d => d.TemplateNavigation)
                    .WithMany(p => p.MaConsolidTemplatesDetail)
                    .HasForeignKey(d => d.Template)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsolidTe_ConsolidTe_00");
            });
            modelBuilder.Entity<MaOwnedCompanies>(entity =>
{
                entity.HasKey(e => e.Company)
                    .HasName("PK_OwnedCompanies")
                    .IsClustered(false);

                entity.ToTable("MA_OwnedCompanies");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyIdentifier)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedConsolidDayMonth)
                    .HasMaxLength(6)
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
            modelBuilder.Entity<MaOwnedCompaniesBalances>(entity =>
{
                entity.HasKey(e => new { e.Company, e.FiscalYear })
                    .HasName("PK_OwnedCompaniesBalances")
                    .IsClustered(false);

                entity.ToTable("MA_OwnedCompaniesBalances");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Excluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExclusionReason)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Final)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
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

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaOwnedCompaniesBalances)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnedCompa_OwnedCompa_00");
            });
            modelBuilder.Entity<MaOwnedCompaniesJe>(entity =>
{
                entity.HasKey(e => new { e.Company, e.SendingDate, e.JournalEntryId })
                    .HasName("PK_OwnedCompaniesJE")
                    .IsClustered(false);

                entity.ToTable("MA_OwnedCompaniesJE");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SendingDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
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

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaOwnedCompaniesJe)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnedCompa_OwnedCompa_02");
            });
            modelBuilder.Entity<MaOwnedCompaniesSendings>(entity =>
{
                entity.HasKey(e => new { e.Company, e.Line })
                    .HasName("PK_OwnedCompaniesSendings")
                    .IsClustered(false);

                entity.ToTable("MA_OwnedCompaniesSendings");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaOwnedCompaniesSendings)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnedCompa_OwnedCompa_01");
            });
            modelBuilder.Entity<MaOwnerCompanies>(entity =>
{
                entity.HasKey(e => e.Company)
                    .HasName("PK_OwnerCompanies")
                    .IsClustered(false);

                entity.ToTable("MA_OwnerCompanies");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedConsolidDayMonth)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
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
            modelBuilder.Entity<MaOwnerCompaniesBalances>(entity =>
{
                entity.HasKey(e => new { e.Company, e.FiscalYear })
                    .HasName("PK_OwnerCompaniesBalances")
                    .IsClustered(false);

                entity.ToTable("MA_OwnerCompaniesBalances");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Excluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExclusionReason)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Final)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
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

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaOwnerCompaniesBalances)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerCompa_OwnerCompa_00");
            });
            modelBuilder.Entity<MaOwnerCompaniesSendings>(entity =>
{
                entity.HasKey(e => new { e.Company, e.Line })
                    .HasName("PK_OwnerCompaniesSendings")
                    .IsClustered(false);

                entity.ToTable("MA_OwnerCompaniesSendings");

                entity.Property(e => e.Company)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.MaOwnerCompaniesSendings)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerCompa_OwnerCompa_01");
            });
        }
    }
}
