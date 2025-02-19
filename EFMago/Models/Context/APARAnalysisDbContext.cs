using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class APARAnalysisDbContext : DbContext
    {
        public APARAnalysisDbContext()
        {
        }
        public APARAnalysisDbContext(DbContextOptions<APARAnalysisDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaPyblsRcvblsParametersAging> MaPyblsRcvblsParametersAging { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaPyblsRcvblsParametersAging>(entity =>
            {
                entity.HasKey(e => e.PyblsRcvblsParametersId)
                    .HasName("PK_PyblsRcvblsParametersAging")
                    .IsClustered(false);

                entity.ToTable("MA_PyblsRcvblsParametersAging");

                entity.Property(e => e.PyblsRcvblsParametersId).ValueGeneratedNever();

                entity.Property(e => e.PyblsPeriod1).HasDefaultValueSql("((0))");

                entity.Property(e => e.PyblsPeriod2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PyblsPeriod3).HasDefaultValueSql("((0))");

                entity.Property(e => e.PyblsPeriod4).HasDefaultValueSql("((0))");

                entity.Property(e => e.PyblsPeriod5).HasDefaultValueSql("((0))");

                entity.Property(e => e.RcvblsPeriod1).HasDefaultValueSql("((0))");

                entity.Property(e => e.RcvblsPeriod2).HasDefaultValueSql("((0))");

                entity.Property(e => e.RcvblsPeriod3).HasDefaultValueSql("((0))");

                entity.Property(e => e.RcvblsPeriod4).HasDefaultValueSql("((0))");

                entity.Property(e => e.RcvblsPeriod5).HasDefaultValueSql("((0))");

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
