using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaAutoincrement> MaAutoincrement { get; set; }
        public virtual DbSet<MaCrossReferences> MaCrossReferences { get; set; }
        public virtual DbSet<MaCrossReferencesNotes> MaCrossReferencesNotes { get; set; }
        public virtual DbSet<MaTmpReport> MaTmpReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaAutoincrement>(entity =>
{
                entity.HasKey(e => e.TableName)
                    .HasName("PK_Autoincrement")
                    .IsClustered(false);

                entity.ToTable("MA_Autoincrement");

                entity.Property(e => e.TableName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.LastId)
                    .HasColumnName("LastID")
                    .HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCrossReferences>(entity =>
{
                entity.HasKey(e => new { e.OriginDocType, e.OriginDocId, e.OriginDocSubId, e.OriginDocLine, e.DerivedDocType, e.DerivedDocId, e.DerivedDocSubId, e.DerivedDocLine })
                    .HasName("PK_CrossReferences")
                    .IsClustered(false);

                entity.ToTable("MA_CrossReferences");

                entity.HasIndex(e => new { e.OriginDocType, e.OriginDocId, e.Manual, e.DerivedDocType, e.DerivedDocId })
                    .HasName("IX_MA_CrossReferences");

                entity.Property(e => e.OriginDocId).HasColumnName("OriginDocID");

                entity.Property(e => e.OriginDocSubId).HasColumnName("OriginDocSubID");

                entity.Property(e => e.DerivedDocId).HasColumnName("DerivedDocID");

                entity.Property(e => e.DerivedDocSubId).HasColumnName("DerivedDocSubID");

                entity.Property(e => e.Manual)
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
            modelBuilder.Entity<MaCrossReferencesNotes>(entity =>
{
                entity.HasKey(e => new { e.OriginDocType, e.OriginDocId, e.DerivedDocType, e.DerivedDocId })
                    .HasName("PK_CrossReferencesNotes")
                    .IsClustered(false);

                entity.ToTable("MA_CrossReferencesNotes");

                entity.Property(e => e.OriginDocId).HasColumnName("OriginDocID");

                entity.Property(e => e.DerivedDocId).HasColumnName("DerivedDocID");

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
            });
            modelBuilder.Entity<MaTmpReport>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Document, e.Line })
                    .HasName("PK_TmpReport")
                    .IsClustered(false);

                entity.ToTable("MA_TmpReport");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(35)
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
