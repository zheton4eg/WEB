using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ����������� DbContext
builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ������������� ���� ������ � �������������� using ��� ��������������� ������������ ��������
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<UniversityContext>();

        // ���������, ��� ���� ������ ������� (�����������)
        // context.Database.EnsureCreated();
        // ��� ��������� ��������:
        // context.Database.Migrate();

        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();