using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SaleOrdersDbContext : DbContext
    {
        public SaleOrdersDbContext()
        {
        }
        public SaleOrdersDbContext(DbContextOptions<SaleOrdersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaAllocationArea> MaAllocationArea { get; set; }
        public virtual DbSet<MaConfirmationLevels> MaConfirmationLevels { get; set; }
        public virtual DbSet<MaSaleOrd> MaSaleOrd { get; set; }
        public virtual DbSet<MaSaleOrdAllocationPriority> MaSaleOrdAllocationPriority { get; set; }
        public virtual DbSet<MaSaleOrdComponents> MaSaleOrdComponents { get; set; }
        public virtual DbSet<MaSaleOrdDetails> MaSaleOrdDetails { get; set; }
        public virtual DbSet<MaSaleOrdNotes> MaSaleOrdNotes { get; set; }
        public virtual DbSet<MaSaleOrdPymtSched> MaSaleOrdPymtSched { get; set; }
        public virtual DbSet<MaSaleOrdReferences> MaSaleOrdReferences { get; set; }
        public virtual DbSet<MaSaleOrdShipping> MaSaleOrdShipping { get; set; }
        public virtual DbSet<MaSaleOrdSummary> MaSaleOrdSummary { get; set; }
        public virtual DbSet<MaSaleOrdTaxSummary> MaSaleOrdTaxSummary { get; set; }
        public virtual DbSet<MaSalesOrdParameters> MaSalesOrdParameters { get; set; }
        public virtual DbSet<MaSalesOrdsDefaults> MaSalesOrdsDefaults { get; set; }
        public virtual DbSet<MaTmpOnHandDetailItems> MaTmpOnHandDetailItems { get; set; }
        public virtual DbSet<MaTmpSaleOrdersAllocation> MaTmpSaleOrdersAllocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaAllocationArea>(entity =>
{
                entity.HasKey(e => e.AllocationArea)
                    .HasName("PK_AllocationArea")
                    .IsClustered(false);

                entity.ToTable("MA_AllocationArea");

                entity.Property(e => e.AllocationArea)
                    .HasMaxLength(8)
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
            modelBuilder.Entity<MaConfirmationLevels>(entity =>
{
                entity.HasKey(e => e.ConfirmationLevel)
                    .HasName("PK_ConfirmationLevels")
                    .IsClustered(false);

                entity.ToTable("MA_ConfirmationLevels");

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BackgroundColour).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintSymbol)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.TextColour).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaSaleOrd>(entity =>
{
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrd")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrd");

                entity.HasIndex(e => e.Allocated)
                    .HasName("MA_SaleOrd7");

                entity.HasIndex(e => e.Delivered)
                    .HasName("MA_SaleOrd5");

                entity.HasIndex(e => e.InternalOrdNo)
                    .HasName("MA_SaleOrd2");

                entity.HasIndex(e => e.Invoiced)
                    .HasName("MA_SaleOrd6");

                entity.HasIndex(e => e.PreShipped)
                    .HasName("MA_SaleOrd8");

                entity.HasIndex(e => new { e.Customer, e.OrderDate })
                    .HasName("MA_SaleOrd3");

                entity.HasIndex(e => new { e.OrderDate, e.InternalOrdNo })
                    .HasName("MA_SaleOrd4");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.AccGroup)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualPercAtInvoiceDate).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AccrualType).HasDefaultValueSql("((3473408))");

                entity.Property(e => e.ActiveSubcontracting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Allocated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllocationArea)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AreaManagerCommTot).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerPolicy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BankAuthorization)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseAreaManager).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseSalesperson).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BlockType).HasDefaultValueSql("((28180480))");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyCa)
                    .HasColumnName("CompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyPymtCa)
                    .HasColumnName("CompanyPymtCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompulsoryDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractType).HasDefaultValueSql("((25690113))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExternalOrdNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromExternalProgram).HasDefaultValueSql("((32505856))");

                entity.Property(e => e.InstallmStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmStartDateIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFollows)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicingCustomer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsBlocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetOfTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NonStandardPayment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                // entity.Property(e => e.Notes)
                //    .HasColumnType("ntext")
                //    .HasDefaultValueSql("('')");

                entity.Property(e => e.OpenOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OurReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Picked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreShipped)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriceListFromDeliveryDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PriceListValidityDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SaleTypeByLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalespersonCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalespersonCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalespersonCommTot).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonPolicy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SentByEmail)
                    .HasColumnName("SentByEMail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SentByPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingReason)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SingleDelivery)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubIdAttivita).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubIdContratto).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubIdDescrizione).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCommunicationGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxJournal)
                    .HasMaxLength(8)
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

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnblockDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.UnblockWorker).HasDefaultValueSql("((0))");

                entity.Property(e => e.UseBusinessYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.YourReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaSaleOrdAllocationPriority>(entity =>
{
                entity.HasKey(e => new { e.PriorityId, e.Priority })
                    .HasName("PK_SaleOrdAllocationPriority")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdAllocationPriority");

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriorityType).HasDefaultValueSql("((25690990))");

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
            modelBuilder.Entity<MaSaleOrdComponents>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.SaleOrdSubId, e.Line })
                    .HasName("PK_SaleOrdComponents")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdComponents");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NeededQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NeededQtyWaste).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteUnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.WasteUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdComponents)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdCom_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdDetails>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.Line })
                    .HasName("PK_SaleOrdDetails")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdDetails");

                entity.HasIndex(e => e.Allocated)
                    .HasName("MA_SaleOrdDetails6");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate })
                    .HasName("MA_SaleOrdDetails3");

                entity.HasIndex(e => new { e.SaleOrdId, e.Position })
                    .HasName("MA_SaleOrdDetails7");

                entity.HasIndex(e => new { e.Delivered, e.ExpectedDeliveryDate, e.Item })
                    .HasName("MA_SaleOrdDetails2");

                entity.HasIndex(e => new { e.ProductionPlanId, e.ProductionPlanLine, e.Item })
                    .HasName("MA_SaleOrdDetails8");

                entity.HasIndex(e => new { e.ExpectedDeliveryDate, e.Item, e.LineType, e.Delivered, e.Cancelled })
                    .HasName("MA_SaleOrdDetails5");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate, e.LineType, e.Delivered, e.Cancelled })
                    .HasName("MA_SaleOrdDetails4");

                entity.Property(e => e.AdditionalQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AllCanoniDataF)
                    .HasColumnName("ALL_CanoniDataF")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AllCanoniDataI)
                    .HasColumnName("ALL_CanoniDataI")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AllNrCanoni)
                    .HasColumnName("ALL_NrCanoni")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Allocated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerComm).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerCommCtgAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BaseAreaManager).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseSalesperson).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Bomitem)
                    .HasColumnName("BOMItem")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BookedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CommissionCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerLotNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InEi)
                    .HasColumnName("InEI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KitQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.NetPrice).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetPriceIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NoDn)
                    .HasColumnName("NoDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PacksUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Picked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickedAndDeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PreShipped)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippedAndDeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PreShippedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionJobId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionJobNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionJobSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionPlanId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionPlanNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReferenceDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceQuotation)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceQuotationId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceQuotationSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferredPosition).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SalespersonComm).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonCommCtgAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonDiscount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdDetails)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdDet_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdNotes>(entity =>
{
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrdNotes")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdNotes");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
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

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.MaSaleOrdNotes)
                    .HasForeignKey<MaSaleOrdNotes>(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdNot_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdPymtSched>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.InstallmentNo })
                    .HasName("PK_SaleOrdPymtSched")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdPymtSched");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DueDateDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.InstallmStartDate).HasDefaultValueSql("((7602177))");

                entity.Property(e => e.InstallmentType).HasDefaultValueSql("((5505024))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdPymtSched)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdPym_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdReferences>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.Line })
                    .HasName("PK_SaleOrdReferences")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdReferences");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684681))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdReferences)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdRef_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdShipping>(entity =>
{
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrdShipping")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdShipping");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.Appearance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossVolumeIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoOfPacksIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PortAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
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

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseOrderPort)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.MaSaleOrdShipping)
                    .HasForeignKey<MaSaleOrdShipping>(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdShi_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdSummary>(entity =>
{
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrdSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdSummary");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Advance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Allowances).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryPercentage).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CollectionChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountOnGoods).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountOnServices).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountsIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.FreeSamples).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmountWithTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PackagingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PayableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PostAdvancesToAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnedMaterial).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmountsWithTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShippingChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StampsChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StampsChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.MaSaleOrdSummary)
                    .HasForeignKey<MaSaleOrdSummary>(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdSum_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdTaxSummary>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.TaxCode })
                    .HasName("PK_SaleOrdTaxSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdTaxSummary");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdTaxSummary)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdTax_SaleOrd_00");
            });
            modelBuilder.Entity<MaSalesOrdParameters>(entity =>
{
                entity.HasKey(e => e.SaleOrdParametersId)
                    .HasName("PK_SalesOrdParameters")
                    .IsClustered(false);

                entity.ToTable("MA_SalesOrdParameters");

                entity.Property(e => e.SaleOrdParametersId).ValueGeneratedNever();

                entity.Property(e => e.AllocationManage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckAllocatedQtyType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.CheckPreShippedQtyType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.CustQuotaExpiringDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultEmptyConfDelivDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisplayFirstSaleOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByArea)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByCarrier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByCig)
                    .HasColumnName("FulfillmentBreakByCIG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByDocBranch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByGoodBranch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByInvRsn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByJob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByPackage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByPort)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByShippRsn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByTcg)
                    .HasColumnName("FulfillmentBreakByTCG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FulfillmentBreakByTransport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PercSaleOrdAllocation).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalesOrdersShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.SortOpenOrders)
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

                entity.Property(e => e.UpdateDnrowsValue)
                    .HasColumnName("UpdateDNRowsValue")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ValidPrices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaSalesOrdsDefaults>(entity =>
{
                entity.HasKey(e => e.SaleOrdsDefaulstId)
                    .HasName("PK_SalesOrdsDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_SalesOrdsDefaults");

                entity.Property(e => e.SaleOrdsDefaulstId).ValueGeneratedNever();

                entity.Property(e => e.EusaleOrderAccTpl)
                    .HasColumnName("EUSaleOrderAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEusaleOrderAccTpl)
                    .HasColumnName("ExtraEUSaleOrderAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrderAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrderInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspTaxSaleOrderAccTpl)
                    .HasMaxLength(8)
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
            modelBuilder.Entity<MaTmpOnHandDetailItems>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.LineType, e.Item, e.DocumentId, e.Line })
                    .HasName("PK_TmpOnHandDetailItems")
                    .IsClustered(false);

                entity.ToTable("MA_TmpOnHandDetailItems");

                entity.HasIndex(e => new { e.Item, e.DeliveryDate, e.LineType })
                    .HasName("MA_TmpOnHandDetailItems2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ActualOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalDataOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandToDueDate1).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandToDueDate2).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandToDueDate3).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandToDueDate4).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandToToday).HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiptedQty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnfulfilledCust).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnfulfilledSupp).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoMdoc)
                    .HasColumnName("UoMDoc")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpSaleOrdersAllocation>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.LineSorted })
                    .HasName("PK_TmpSaleOrdersAllocation")
                    .IsClustered(false);

                entity.ToTable("MA_TmpSaleOrdersAllocation");

                entity.HasIndex(e => e.SaleOrdId)
                    .HasName("MA_TmpSaleOrdersAllocation5");

                entity.HasIndex(e => new { e.Item, e.AllocationArea })
                    .HasName("MA_TmpSaleOrdersAllocation3");

                entity.HasIndex(e => new { e.Item, e.SaleOrdId, e.Line })
                    .HasName("MA_TmpSaleOrdersAllocation2");

                entity.HasIndex(e => new { e.Item, e.LineSorted, e.UserName, e.Computer })
                    .HasName("MA_TmpSaleOrdersAllocation4");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllocableQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Allocated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllocatedBaseUoMqty)
                    .HasColumnName("AllocatedBaseUoMQty")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AllocationArea)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AvailabilityDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AvailableQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseUoMqty)
                    .HasColumnName("BaseUoMQty")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Carrier)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerBlocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustomerCategory)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsInGrid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsSelected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Line).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.PreShippedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProgressiveAvailableQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SingleDelivery)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
