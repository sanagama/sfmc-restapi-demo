
using Microsoft.EntityFrameworkCore;
using Serilog;
using SfmcRestApiDemo.Models;

namespace SfmcRestApiDemo
{
    public class SfmcContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Email> Emails { get; set; }

        public SfmcContext() : base()
        {
            Log.Information("Initializing SfmcContext");
        }
        public SfmcContext(DbContextOptions options) : base(options)
        {
            Log.Information("Initializing SfmcContext");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nothing to do currently
        }
    }
}