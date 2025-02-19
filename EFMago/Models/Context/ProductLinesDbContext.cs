using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ProductLinesDbContext : DbContext
    {
        public ProductLinesDbContext()
        {
        }
        public ProductLinesDbContext(DbContextOptions<ProductLinesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaProductLineGroups> MaProductLineGroups { get; set; }
        public virtual DbSet<MaProductLines> MaProductLines { get; set; }
        public virtual DbSet<MaProductLinesBalances> MaProductLinesBalances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaProductLineGroups>(entity =>
{
                entity.HasKey(e => e.GroupCode)
                    .HasName("PK_ProductLineGroups")
                    .IsClustered(false);

                entity.ToTable("MA_ProductLineGroups");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ProductLineGroups2");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            modelBuilder.Entity<MaProductLines>(entity =>
{
                entity.HasKey(e => e.ProductLine)
                    .HasName("PK_ProductLines")
                    .IsClustered(false);

                entity.ToTable("MA_ProductLines");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ProductLines2");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DepreciationPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupCode)
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
            modelBuilder.Entity<MaProductLinesBalances>(entity =>
{
                entity.HasKey(e => new { e.ProductLine, e.Account, e.FiscalYear, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_ProductLinesBalances")
                    .IsClustered(false);

                entity.ToTable("MA_ProductLinesBalances");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ActualCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebitQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetDebitQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastDebitQty).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ProductLineNavigation)
                    .WithMany(p => p.MaProductLinesBalances)
                    .HasForeignKey(d => d.ProductLine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductLin_ProductLin_00");
            });
        }
    }
}
