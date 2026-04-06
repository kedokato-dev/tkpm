using Microsoft.EntityFrameworkCore;
using Library.Core.Interfaces;
using Library.Data;
using Library.Data.Repositories;
using Library.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<QuanLyThuVienContext>(options =>
    options.UseMySQL(connectionString!));

// Register Repository (DAL)
builder.Services.AddScoped<ISachRepository, SachRepository>();

// Register Service (BLL)
builder.Services.AddScoped<ISachService, SachService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
