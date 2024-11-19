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
                base.OnModelCreating(modelBuilder);


                // Define the relationships first, always:


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

            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.CollectionRecipes)
                .WithOne(cr => cr.Recipe)
                .HasForeignKey(cr => cr.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);


            // User to Recipes relationship seeds
            modelBuilder.Entity<User>().HasData(
                new User 
                {
                    Id = 1,
                    Username = "John Doe", // Example property
                    Email = "john.doe@example.com",
                    PasswordHash = "Foodie123",
                    CreatedAt = DateTime.UtcNow,
                },
                new User 
                {
                    Id = 2,
                    Username = "Jane Smith", // Example property
                    Email = "jane.smith@example.com",
                    PasswordHash = "Burgers345",
                    CreatedAt = DateTime.UtcNow,
                }
            );

            // Recipe to CollectionRecipes relationship seeds 
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    UserId = 1, 
                    Title = "Spaghetti Bolognese",
                    Ingredients = "Spaghetti, minced beef, tomato sauce, onions, garlic",
                    Description = "A classic Italian pasta dish.",
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CookingTime = 30
                }, 
                new Recipe {
                    Id = 2,
                    UserId = 2,
                    Title = "Vegetable Stir Fry",
                    Ingredients = "Mixed vegetables, soy sauce, garlic, ginger",
                    Description = "A quick and healthy stir fry.",
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CookingTime = 15
                }
            );
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

