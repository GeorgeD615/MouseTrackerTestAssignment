using Microsoft.EntityFrameworkCore;
using MouseTrackerTestAssignment.Db;
using MouseTrackerTestAssignment.Db.Implementations;
using MouseTrackerTestAssignment.Db.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("mouse_tracker");

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMouseTrackerDbRepository, MouseTrackerDbRepository>();

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
    pattern: "{controller=Mouse}/{action=Index}/{id?}");

app.Run();
