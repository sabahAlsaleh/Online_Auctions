using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectApplication.Core;
using ProjectApplication.Core.Interfaces;
using ProjectApplication.DataAccess;
using Microsoft.AspNetCore.Identity;
using ProjectApplication.Data;
using ProjectApplication.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPresistence>();


// db with dependecy injection
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));


// identity configuration
// the first statement is missing from the scaffolding
builder.Services.AddDbContext<ProjectApplicationIdentityContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectApplicationIdentityContextConnection")));
builder.Services.AddDefaultIdentity<ProjectApplicationUser>(options =>options.SignIn.RequireConfirmedAccount= true).AddEntityFrameworkStores<ProjectApplicationIdentityContext>();

builder.Services.AddAutoMapper(typeof(Program));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{activeAuctions?}");


app.MapRazorPages();
app.Run();
