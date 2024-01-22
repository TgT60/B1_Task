using B1_Task.Controllers.ProcessHub;
using B1_Task.Entity;
using B1_Task.Function.Document;
using B1_Task.Function.Excel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDocumentFunction, DocumentFunction>();
builder.Services.AddTransient<IExcelFunction, ExcelFunction>();
builder.Services.AddTransient<ProcessHub>();
builder.Services.AddDbContext<B1Context>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Excel}/{action=ExcelFileReader}/{id?}");

app.MapHub<ProcessHub>("/ProcessHub");

app.Run();
