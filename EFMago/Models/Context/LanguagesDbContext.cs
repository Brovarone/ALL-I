using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class LanguagesDbContext : DbContext
    {
        public LanguagesDbContext()
        {
        }
        public LanguagesDbContext(DbContextOptions<LanguagesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaChartOfAccountsLang> MaChartOfAccountsLang { get; set; }
        public virtual DbSet<MaCircularLetterTemplatesLg> MaCircularLetterTemplatesLg { get; set; }
        public virtual DbSet<MaInventoryReasonsLang> MaInventoryReasonsLang { get; set; }
        public virtual DbSet<MaItemsLanguageDescri> MaItemsLanguageDescri { get; set; }
        public virtual DbSet<MaJobsLang> MaJobsLang { get; set; }
        public virtual DbSet<MaLanguages> MaLanguages { get; set; }
        public virtual DbSet<MaPackagesLang> MaPackagesLang { get; set; }
        public virtual DbSet<MaPaymentTermsLang> MaPaymentTermsLang { get; set; }
        public virtual DbSet<MaPortsLang> MaPortsLang { get; set; }
        public virtual DbSet<MaPriceListsLang> MaPriceListsLang { get; set; }
        public virtual DbSet<MaProductCtgLang> MaProductCtgLang { get; set; }
        public virtual DbSet<MaTaxCodesLang> MaTaxCodesLang { get; set; }
        public virtual DbSet<MaTitlesLang> MaTitlesLang { get; set; }
        public virtual DbSet<MaTransportLang> MaTransportLang { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaChartOfAccountsLang>(entity =>
{
                entity.HasKey(e => new { e.Account, e.Language })
                    .HasName("PK_ChartOfAccountsLang")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccountsLang");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.MaChartOfAccountsLang)
                    .HasForeignKey(d => d.Account)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartOfAcc_Account_00");
            });
            modelBuilder.Entity<MaCircularLetterTemplatesLg>(entity =>
{
                entity.HasKey(e => new { e.Template, e.Language })
                    .HasName("PK_CircularLetterTemplatesLg")
                    .IsClustered(false);

                entity.ToTable("MA_CircularLetterTemplatesLg");

                entity.Property(e => e.Template)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FileNamespace)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileNamespaceMail)
                    .HasMaxLength(128)
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

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaInventoryReasonsLang>(entity =>
{
                entity.HasKey(e => new { e.Reason, e.Language })
                    .HasName("PK_InventoryReasonsLang")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryReasonsLang");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.ReasonNavigation)
                    .WithMany(p => p.MaInventoryReasonsLang)
                    .HasForeignKey(d => d.Reason)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryR_InventoryR_00");
            });
            modelBuilder.Entity<MaItemsLanguageDescri>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Language })
                    .HasName("PK_ItemsLanguageDescri")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsLanguageDescri");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionText)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PublicNote)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsLanguageDescri)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsLangu_Items_00");
            });
            modelBuilder.Entity<MaJobsLang>(entity =>
{
                entity.HasKey(e => new { e.Job, e.Language })
                    .HasName("PK_JobsLang")
                    .IsClustered(false);

                entity.ToTable("MA_JobsLang");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
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

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.MaJobsLang)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobsLang_Jobs_00");
            });
            modelBuilder.Entity<MaLanguages>(entity =>
{
                entity.HasKey(e => e.Language)
                    .HasName("PK_Languages")
                    .IsClustered(false);

                entity.ToTable("MA_Languages");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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
            });
            modelBuilder.Entity<MaPackagesLang>(entity =>
{
                entity.HasKey(e => new { e.Package, e.Language })
                    .HasName("PK_PackagesLang")
                    .IsClustered(false);

                entity.ToTable("MA_PackagesLang");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.PackageNavigation)
                    .WithMany(p => p.MaPackagesLang)
                    .HasForeignKey(d => d.Package)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackagesLa_Packages_00");
            });
            modelBuilder.Entity<MaPaymentTermsLang>(entity =>
{
                entity.HasKey(e => new { e.Payment, e.Language })
                    .HasName("PK_PaymentTermsLang")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentTermsLang");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionText)
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

                entity.HasOne(d => d.PaymentNavigation)
                    .WithMany(p => p.MaPaymentTermsLang)
                    .HasForeignKey(d => d.Payment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTer_PaymentTer_00");
            });
            modelBuilder.Entity<MaPortsLang>(entity =>
{
                entity.HasKey(e => new { e.Port, e.Language })
                    .HasName("PK_PortsLang")
                    .IsClustered(false);

                entity.ToTable("MA_PortsLang");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.PortNavigation)
                    .WithMany(p => p.MaPortsLang)
                    .HasForeignKey(d => d.Port)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortsLang_Ports_00");
            });
            modelBuilder.Entity<MaPriceListsLang>(entity =>
{
                entity.HasKey(e => new { e.PriceList, e.Language })
                    .HasName("PK_PriceListsLang")
                    .IsClustered(false);

                entity.ToTable("MA_PriceListsLang");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.PriceListNavigation)
                    .WithMany(p => p.MaPriceListsLang)
                    .HasForeignKey(d => d.PriceList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceLists_PriceLists_00");
            });
            modelBuilder.Entity<MaProductCtgLang>(entity =>
{
                entity.HasKey(e => new { e.ProductCtg, e.Language })
                    .HasName("PK_ProductCtgLang")
                    .IsClustered(false);

                entity.ToTable("MA_ProductCtgLang");

                entity.Property(e => e.ProductCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.ProductCtgNavigation)
                    .WithMany(p => p.MaProductCtgLang)
                    .HasForeignKey(d => d.ProductCtg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCtgLan_ProductCtg_00");
            });
            modelBuilder.Entity<MaTaxCodesLang>(entity =>
{
                entity.HasKey(e => new { e.TaxCode, e.Language })
                    .HasName("PK_TaxCodesLang")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCodesLang");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.TaxCodeNavigation)
                    .WithMany(p => p.MaTaxCodesLang)
                    .HasForeignKey(d => d.TaxCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxCodesLang_TaxCodes_00");
            });
            modelBuilder.Entity<MaTitlesLang>(entity =>
{
                entity.HasKey(e => new { e.TitleCode, e.Language })
                    .HasName("PK_TitlesLang")
                    .IsClustered(false);

                entity.ToTable("MA_TitlesLang");

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.TitleCodeNavigation)
                    .WithMany(p => p.MaTitlesLang)
                    .HasForeignKey(d => d.TitleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitlesLang_Titles_00");
            });
            modelBuilder.Entity<MaTransportLang>(entity =>
{
                entity.HasKey(e => new { e.ModeOfTransport, e.Language })
                    .HasName("PK_TransportLang")
                    .IsClustered(false);

                entity.ToTable("MA_TransportLang");

                entity.Property(e => e.ModeOfTransport)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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

                entity.HasOne(d => d.ModeOfTransportNavigation)
                    .WithMany(p => p.MaTransportLang)
                    .HasForeignKey(d => d.ModeOfTransport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportL_Transport_00");
            });
        }
    }
}
