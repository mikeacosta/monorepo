using BethanysPieShop.Data;
using BethanysPieShop.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddSingleton<IPieRepository, MockPieRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();