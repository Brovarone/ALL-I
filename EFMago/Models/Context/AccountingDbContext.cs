using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class AccountingDbContext : DbContext
    {
        public AccountingDbContext()
        {
        }
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaJournalEntries> MaJournalEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurazione non trovata per l'entità MaJournalEntries
        }
    }
}
