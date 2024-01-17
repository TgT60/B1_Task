using B1_Task.Entity;
using B1_Task.Function.Document;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDocumentFunction, DocumentFunction>();
builder.Services.AddDbContext<B1Context>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

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
	pattern: "{controller=Document}/{action=Index}/{id?}");

app.Run();
