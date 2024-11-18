using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PRO05_backend_riley_tanya_dani_levi.Data; // Add this namespace

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "CookNest API",
         Description = "Making the recipes you love",
         Version = "v1" });
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

app.MapGet("/", () => "Hello World!");

//Testing Comment

app.Run();