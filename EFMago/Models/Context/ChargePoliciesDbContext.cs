using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ChargePoliciesDbContext : DbContext
    {
        public ChargePoliciesDbContext()
        {
        }
        public ChargePoliciesDbContext(DbContextOptions<ChargePoliciesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaChargePolicies> MaChargePolicies { get; set; }
        public virtual DbSet<MaChargePoliciesAreas> MaChargePoliciesAreas { get; set; }
        public virtual DbSet<MaChargePoliciesPackages> MaChargePoliciesPackages { get; set; }
        public virtual DbSet<MaChargePoliciesShippings> MaChargePoliciesShippings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaChargePolicies>(entity =>
{
                entity.HasKey(e => e.Customer)
                    .HasName("PK_ChargePolicies")
                    .IsClustered(false);

                entity.ToTable("MA_ChargePolicies");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PackageFormula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageRounding).HasDefaultValueSql("((0))");

                entity.Property(e => e.PackageRoundingType).HasDefaultValueSql("((6553602))");

                entity.Property(e => e.ShippingFormula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingRounding).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShippingRoundingType).HasDefaultValueSql("((6553602))");

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
            modelBuilder.Entity<MaChargePoliciesAreas>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.Area })
                    .HasName("PK_ChargePoliciesAreas")
                    .IsClustered(false);

                entity.ToTable("MA_ChargePoliciesAreas");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Percentage).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.MaChargePoliciesAreas)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChargePoli_ChargePoli_02");
            });
            modelBuilder.Entity<MaChargePoliciesPackages>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.CalculationType })
                    .HasName("PK_ChargePoliciesPackages")
                    .IsClustered(false);

                entity.ToTable("MA_ChargePoliciesPackages");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Limit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Percentage).HasDefaultValueSql("((0))");

                entity.Property(e => e.Rounding).HasDefaultValueSql("((6553602))");

                entity.Property(e => e.RoundingType).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.MaChargePoliciesPackages)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChargePoli_ChargePoli_01");
            });
            modelBuilder.Entity<MaChargePoliciesShippings>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.CalculationType })
                    .HasName("PK_ChargePoliciesShippings")
                    .IsClustered(false);

                entity.ToTable("MA_ChargePoliciesShippings");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Limit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Percentage).HasDefaultValueSql("((0))");

                entity.Property(e => e.Rounding).HasDefaultValueSql("((0))");

                entity.Property(e => e.RoundingType).HasDefaultValueSql("((6553602))");

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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.MaChargePoliciesShippings)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChargePoli_ChargePoli_00");
            });
        }
    }
}
