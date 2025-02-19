using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class Accounting_CNDbContext : DbContext
    {
        public Accounting_CNDbContext()
        {
        }
        public Accounting_CNDbContext(DbContextOptions<Accounting_CNDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaLedgersTypes> MaLedgersTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaLedgersTypes>(entity =>
{
                entity.HasKey(e => e.Code)
                    .HasName("PK_LedgersTypes")
                    .IsClustered(false);

                entity.ToTable("MA_LedgersTypes");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nature).HasDefaultValueSql("((3014656))");

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
