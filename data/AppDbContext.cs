using Microsoft.EntityFrameworkCore;

namespace PRO05_backend_riley_tanya_dani_levi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {
                
            Users = Set<User>();
            Recipes = Set<Recipe>();
            Collections = Set<Collection>();
            CollectionRecipes = Set<CollectionRecipe>();

            }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionRecipe> CollectionRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User to Recipes relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Recipes)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User to Collections relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Collections)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Collection to CollectionRecipes relationship
            modelBuilder.Entity<Collection>()
                .HasMany(c => c.CollectionRecipes)
                .WithOne(cr => cr.Collection)
                .HasForeignKey(cr => cr.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Recipe to CollectionRecipes relationship
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.CollectionRecipes)
                .WithOne(cr => cr.Recipe)
                .HasForeignKey(cr => cr.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}