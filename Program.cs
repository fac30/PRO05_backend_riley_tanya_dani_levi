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
    return await db.Recipes.ToListAsync();
});

app.Run();