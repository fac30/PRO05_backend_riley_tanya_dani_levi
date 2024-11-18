var builder = WebApplication.CreateBuilder(args);
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
