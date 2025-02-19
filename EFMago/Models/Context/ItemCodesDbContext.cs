using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ItemCodesDbContext : DbContext
    {
        public ItemCodesDbContext()
        {
        }
        public ItemCodesDbContext(DbContextOptions<ItemCodesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaItemCodes> MaItemCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaItemCodes>(entity =>
{
                entity.HasKey(e => e.Code)
                    .HasName("PK_ItemCodes")
                    .IsClustered(false);

                entity.ToTable("MA_ItemCodes");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ItemCodes2");

                entity.Property(e => e.Code)
                    .HasMaxLength(16)
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
        }
    }
}
