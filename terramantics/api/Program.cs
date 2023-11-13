using api.Data;
using api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<HouseDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySQL(builder.Configuration["ConnectionStrings:TerramanticsConnectionString"])
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    );
builder.Services.AddScoped<IHouseRepository, HouseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000")
    .AllowAnyHeader().AllowAnyMethod()
);

app.UseHttpsRedirection();

app.MapGet("/houses", (IHouseRepository repo) => repo.GetAll());
app.MapGet("/houses/{houseId:int}", async (int houseId, IHouseRepository repo) => 
{
    var house = await repo.Get(houseId);
    if (house == null)
        return Results.Problem($"House with ID {houseId} not found.", statusCode: 404);
    return Results.Ok(house);
}).ProducesProblem(404).Produces<HouseDetailDto>(StatusCodes.Status200OK);

app.MapPost("/houses", async ([FromBody] HouseDetailDto dto, IHouseRepository repo) => 
{
    var newHouse = await repo.Add(dto);
    return Results.Created($"/house/{newHouse.Id}", newHouse);
}).ProducesValidationProblem().Produces<HouseDetailDto>(StatusCodes.Status201Created);

app.MapPut("/houses", async ([FromBody] HouseDetailDto dto, IHouseRepository repo) => 
{
    var updatedHouse = await repo.Update(dto);
    if (await repo.Get(dto.Id) == null)
        return Results.Problem($"House with Id {dto.Id} not found", statusCode: 404);    
    return Results.Ok(updatedHouse);
}).ProducesValidationProblem().ProducesProblem(404).Produces<HouseDetailDto>(StatusCodes.Status200OK);

app.MapDelete("/houses/{houseId:int}", async (int houseId, IHouseRepository repo) => 
{
    if (await repo.Get(houseId) == null)
        return Results.Problem($"House with Id {houseId} not found", statusCode: 404);
    await repo.Delete(houseId);
    return Results.Ok();
}).ProducesProblem(404).Produces(StatusCodes.Status200OK);

app.Run();