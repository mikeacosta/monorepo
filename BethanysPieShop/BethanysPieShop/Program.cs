using BethanysPieShop.Data;
using BethanysPieShop.Models;
using BethanysPieShop.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession(); 
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();