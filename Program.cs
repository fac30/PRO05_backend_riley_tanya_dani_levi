using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PRO05_backend_riley_tanya_dani_levi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "CookNest API",
         Description = "Making the recipes you love",
         Version = "v1" });
});

// to configure CORS for connection with frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("*") // Replace with your frontend URL when ready
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add database context configuration BEFORE app.Build()
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "CookNest API V1");
   });
}

// Enable CORS
app.UseCors("AllowFrontend");

app.MapGet("/recipes", async (AppDbContext db) => 
{
    return await db.Recipes
        .Include(r => r.User) // Eagerly load the User entity
        .Select(r => new 
        {
            r.Title,
            r.UserId,
            r.Ingredients,
            r.Description,
            r.CookingTime,
            Username = r.User != null ? r.User.Username : "Unknown" // Safeguard for null User
        })
        .ToListAsync();
});

app.MapGet("/users", async (AppDbContext db) => 
{
    return await db.Users.Select(u => new 
    {
        u.Username
    }).ToListAsync();
});

app.MapPost("/recipes", async (AppDbContext db, RecipeDto recipeDto) => 
{
    var recipe = new Recipe 
    {
        Title = recipeDto.Title,
        Ingredients = string.Join(", ", recipeDto.Ingredients), // Convert List<string> to a comma-separated string
        Description = recipeDto.Description,
        CookingTime = recipeDto.CookingTime,
        UserId = recipeDto.UserId // Set UserId from DTO
    };

    db.Recipes.Add(recipe);
    await db.SaveChangesAsync();
    return Results.Created($"/recipes/{recipe.Id}", recipe);
});

app.Run();