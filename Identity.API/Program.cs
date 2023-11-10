using Identity.API.Configurations;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();
    
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
await app.ConfigureAsync();

await app.RunAsync();