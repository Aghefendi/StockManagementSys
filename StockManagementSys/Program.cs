using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Concreate.Repositories;
using DataAccessLayer.Abstract;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnits, UnitRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<ISupplier, SupplierRepository>();

builder.Services.AddScoped<IInward, InwardRepository>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IControlCheck, ControlCheckRepository>();
builder.Services.AddScoped<IPurchaseOrder,PurchaseOrderRepo>();
builder.Services.AddScoped<IOutward, OutwardRepository>();


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
