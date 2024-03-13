using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QrSystem.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Entity Framework Core kullanarak veritaban� ba�lant�s�n� yap�land�r�n
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_aa64c4_qrsystem;User Id=db_aa64c4_qrsystem_admin;Password=ferid2003");
});


// Session kullan�m�n� etkinle�tirin
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman a��m� s�resi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
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

app.UseSession(); // Middleware'yi buraya ta��d�k
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Product}/{action=Index}/{qrCodeid?}");

    endpoints.MapDefaultControllerRoute();
});
app.Run();