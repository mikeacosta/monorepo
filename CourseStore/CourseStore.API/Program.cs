using CourseStore.API.Data;
using CourseStore.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions => dbContextOptions.UseNpgsql(
        builder.Configuration["ConnectionStrings:DbConnectionString"]));

builder.Services.AddScoped<ICourseStoreRepository, CourseStoreRepository>();
builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddControllers();

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.Add("server", Environment.MachineName);
    };
});
    
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });   
}

app.UseHttpsRedirection();

// routing matches a request UTI to an action on a controller

// adds route matching to the middleware pipeline.
// This middleware looks at the set of endpoints defined in the app, and selects the best match based on the request.
app.UseRouting();

//app.UseAuthorization();

// adds endpoint execution to the middleware pipeline. It runs the delegate associated with the selected endpoint.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// replaces app.UseRouting and app.UseEndpoints
//app.MapControllers();

app.Run();