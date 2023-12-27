using JockStop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions.UseNpgsql(
        builder.Configuration["ConnectionStrings:ProductConnection"]));

builder.Services.AddControllers();

var app = builder.Build();

// configure HTTP request pipeline
app.UseMiddleware<JockStop.TestMiddleware>();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();
