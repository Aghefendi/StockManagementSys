using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Repositories;
using Microsoft.AspNetCore.Identity;
using StockManagementSys;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnits, UnitRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IBrand, BrandRepository>();
builder.Services.AddScoped<IProductProfile, ProductProfileRepository>();
builder.Services.AddScoped<IProductGroup, ProductGroupRepository>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddDbContext<InventoryContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<InventoryContext>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
