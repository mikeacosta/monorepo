using Api.Data;
using Api.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DBConnectionString"]);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IHouseRepository, HouseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.MapGet("/houses", (IHouseRepository repo) =>
    repo.GetAllAsync());

app.Run();
