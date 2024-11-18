using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Data; // Add this namespace

var builder = WebApplication.CreateBuilder(args);

// Add database context configuration BEFORE app.Build()
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

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