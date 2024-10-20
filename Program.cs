var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews(); // This line is necessary to enable MVC

var app = builder.Build();

// Configure the HTTP request pipeline (if you need static files, etc.)
// app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Insulin}/{action=Index}/{id?}");
});

app.Run();
