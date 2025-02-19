using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ConfiguratorDbContext : DbContext
    {
        public ConfiguratorDbContext()
        {
        }
        public ConfiguratorDbContext(DbContextOptions<ConfiguratorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaConfigurations> MaConfigurations { get; set; }
        public virtual DbSet<MaConfigurationsAnswers> MaConfigurationsAnswers { get; set; }
        public virtual DbSet<MaConfigurationsIncompat> MaConfigurationsIncompat { get; set; }
        public virtual DbSet<MaConfigurationsQnA> MaConfigurationsQnA { get; set; }
        public virtual DbSet<MaConfigurationsQuestions> MaConfigurationsQuestions { get; set; }
        public virtual DbSet<MaConfiguratorParameters> MaConfiguratorParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaConfigurations>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Configuration })
                    .HasName("PK_Configurations")
                    .IsClustered(false);

                entity.ToTable("MA_Configurations");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Configuration)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaConfigurationsAnswers>(entity =>
{
                entity.HasKey(e => new { e.QuestionNo, e.AnswerNo })
                    .HasName("PK_ConfigurationsAnswers")
                    .IsClustered(false);

                entity.ToTable("MA_ConfigurationsAnswers");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Answer)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.QuestionNoNavigation)
                    .WithMany(p => p.MaConfigurationsAnswers)
                    .HasForeignKey(d => d.QuestionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Configurat_Configurat_01");
            });
            modelBuilder.Entity<MaConfigurationsIncompat>(entity =>
{
                entity.HasKey(e => new { e.QuestionNo, e.AnswerNo, e.IncompatQuestionNo, e.IncompatAnswerNo })
                    .HasName("PK_ConfigurationsIncompat")
                    .IsClustered(false);

                entity.ToTable("MA_ConfigurationsIncompat");

                entity.HasIndex(e => new { e.QuestionNo, e.AnswerNo })
                    .HasName("IX_MA_ConfigurationsIncompat");

                entity.HasIndex(e => new { e.IncompatQuestionNo, e.IncompatAnswerNo, e.QuestionNo, e.AnswerNo })
                    .HasName("IX_MA_ConfigurationsIncompat_1");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IncompatQuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaConfigurationsQnA>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Configuration, e.QuestionNo })
                    .HasName("PK_ConfigurationsQnA")
                    .IsClustered(false);

                entity.ToTable("MA_ConfigurationsQnA");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Configuration)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AnswerNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeleteComponent)
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

                entity.HasOne(d => d.MaConfigurations)
                    .WithMany(p => p.MaConfigurationsQnA)
                    .HasForeignKey(d => new { d.Item, d.Configuration })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Configurat_Configurat_00");
            });
            modelBuilder.Entity<MaConfigurationsQuestions>(entity =>
{
                entity.HasKey(e => e.QuestionNo)
                    .HasName("PK_ConfigurationsQuestions")
                    .IsClustered(false);

                entity.ToTable("MA_ConfigurationsQuestions");

                entity.HasIndex(e => e.Question)
                    .HasName("IX_MA_ConfigurationsQuestions");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Deletable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeletingText)
                    .HasMaxLength(64)
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

                entity.Property(e => e.Question)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaConfiguratorParameters>(entity =>
{
                entity.HasKey(e => e.ConfiguratorParametersId)
                    .HasName("PK_ConfiguratorParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ConfiguratorParameters");

                entity.Property(e => e.ConfiguratorParametersId).ValueGeneratedNever();

                entity.Property(e => e.BasePriceListConfComp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BasePriceListStdItem)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfigurationAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfigurationMaxChar).HasDefaultValueSql("((4))");

                entity.Property(e => e.ExplosionMaxLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastConfiguration).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastQuestion).HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceListConfComp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriceListStdItem)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PricePrompt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuestionAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuestionMaxChar).HasDefaultValueSql("((4))");

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

                entity.Property(e => e.UseDocPriceListConfComp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDocPriceListStdItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
        }
    }
}
