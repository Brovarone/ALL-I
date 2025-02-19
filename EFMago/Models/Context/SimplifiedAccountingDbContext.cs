using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SimplifiedAccountingDbContext : DbContext
    {
        public SimplifiedAccountingDbContext()
        {
        }
        public SimplifiedAccountingDbContext(DbContextOptions<SimplifiedAccountingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaSimplifiedAccountingGrps> MaSimplifiedAccountingGrps { get; set; }
        public virtual DbSet<MaSimplifiedAccountingTots> MaSimplifiedAccountingTots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaSimplifiedAccountingGrps>(entity =>
{
                entity.HasKey(e => new { e.ColumnCode, e.Account, e.DebitCreditSign })
                    .HasName("PK_SimplifiedAccountingGrps")
                    .IsClustered(false);

                entity.ToTable("MA_SimplifiedAccountingGrps");

                entity.Property(e => e.ColumnCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.IgnoreDifferentSign)
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
            });
            modelBuilder.Entity<MaSimplifiedAccountingTots>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.BalanceYear, e.BalanceMonth, e.ColumnCode })
                    .HasName("PK_SimplifiedAccountingTots")
                    .IsClustered(false);

                entity.ToTable("MA_SimplifiedAccountingTots");

                entity.Property(e => e.ColumnCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

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
