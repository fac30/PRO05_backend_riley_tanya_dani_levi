using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "CookNest API",
         Description = "Making the recipes you love",
         Version = "v1" });
});

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


app.MapPost("/signup", (User user) => 
{
return UserDB.CreatneUser(user);
});
app.MapPost("/login", (LoginRequest loginRequest) => 
{
return UserDB.AuthenticateUser(loginRequest);
});

app.Run();
