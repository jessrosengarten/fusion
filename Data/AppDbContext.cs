using Microsoft.EntityFrameworkCore;
using TicketStatusAPI;
using TicketStatusAPI.Models;

namespace TicketStatusAPI.Data
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Output connection string (debugging)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {
            Console.WriteLine("DB Connection String: " + Database.GetDbConnection().ConnectionString);
        }

        // These represent the tables
        public DbSet<Ticket> Tickets { get; set; }  // DbSet for Ticket
        public DbSet<Lookup> Lookups { get; set; }  // DbSet for Lookup
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between Tickets and Lookup table
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.StatusLookup)
                .WithMany()
                .HasForeignKey(t => t.tStatus)
                .HasPrincipalKey(l => l.LookupID);

            // Map columns explicitly
            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.ToTable("Lookup");
                entity.Property(e => e.Class).HasColumnName("Class");
                entity.Property(e => e.Value).HasColumnName("Value");
            });
        }
    }
}
