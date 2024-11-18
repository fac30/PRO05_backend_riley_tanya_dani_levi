using Microsoft.EntityFrameworkCore;

namespace YourProjectName.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor to receive database configuration options
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}

        // Define database tables as DbSet properties
        public DbSet<User> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }

        // Optional: Configure relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example: Configure relationships
            modelBuilder.Entity<Collection>()
                .HasOne(c => c.User)
                .WithMany(u => u.Collections)
                .HasForeignKey(c => c.UserId);
        }
    }
}