using ContosoUniversity.Data;
using ContosoUniversity3.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//////////////////////////////////////////////////////////////////////////

IServiceScope scope = app.Services.CreateScope();
IServiceProvider services = scope.ServiceProvider;

UniversityContext context = services.GetRequiredService<UniversityContext>();
DbInitializer.Initialize(context);

//////////////////////////////////////////////////////////////////////////
///

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
