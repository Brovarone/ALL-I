using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21

namespace EFMago.Models
{
    public partial class AccountingCHDbContext : DbContext
    {
        public AccountingCHDbContext()
        {
        }

        public AccountingCHDbContext(DbContextOptions<AccountingCHDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaTaxStatement> MaTaxStatement { get; set; }
        public virtual DbSet<MaTaxStatementDetails> MaTaxStatementDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //  {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //       optionsBuilder.UseSqlServer("Server=ACERBO\\SQLEXPRESS; Database=DEMON;User Id=sa;Password=euroufficio");
            //   }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaTaxStatement>(entity =>
            {
                entity.HasKey(e => e.TaxRegime)
                    .HasName("PK_TaxStatement")
                    .IsClustered(false);

                entity.ToTable("MA_TaxStatement");

                entity.Property(e => e.TaxRegime).ValueGeneratedNever();

                entity.Property(e => e.AmountWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

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

            modelBuilder.Entity<MaTaxStatementDetails>(entity =>
            {
                entity.HasKey(e => new { e.TaxRegime, e.TaxStatementCode, e.TaxCode })
                    .HasName("PK_TaxStatementDetails")
                    .IsClustered(false);

                entity.ToTable("MA_TaxStatementDetails");

                entity.Property(e => e.TaxStatementCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
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

        }
    }
}
