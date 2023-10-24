var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Stephan Van Hemelrijck!");

// Make post endpoint
app.MapPost("/post", () => "Hello Stephan Van Hemelrijck!");

app.Run();
