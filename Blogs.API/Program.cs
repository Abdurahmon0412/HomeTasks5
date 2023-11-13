using Blogs.API.Configurations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();
var app = builder.Build();
await app.ConfigureAsync();
await app.RunAsync();