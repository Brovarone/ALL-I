using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class Accounting_GRDbContext : DbContext
    {
        public Accounting_GRDbContext()
        {
        }
        public Accounting_GRDbContext(DbContextOptions<Accounting_GRDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaTmpTrialBalance> MaTmpTrialBalance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaTmpTrialBalance>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Line })
                    .HasName("PK_TmpTrialBalance")
                    .IsClustered(false);

                entity.ToTable("MA_TmpTrialBalance");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreviousCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.PreviousDebit).HasDefaultValueSql("((0))");

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
