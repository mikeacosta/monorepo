using HoopsPlayersAPI.Entities;
using HoopsPlayersAPI.Logic;
using HoopsPlayersAPI.Middleware;
using Microsoft.EntityFrameworkCore;

// http://bit.ly/aspnet-builder-defaults
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions.UseNpgsql(
        builder.Configuration["ConnectionStrings:DefaultConnectionString"]));

builder.Services.AddCors(options => options.AddPolicy(name: "HoopsPlayersOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddScoped<IPlayerLogic, PlayerLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HoopsPlayersOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();