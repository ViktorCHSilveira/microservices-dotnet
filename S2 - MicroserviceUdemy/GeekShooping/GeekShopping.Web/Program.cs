using GeekShopping.web.Services;
using GeekShopping.web.Services.ISercies;

var builder = WebApplication.CreateBuilder(args);

var Services = builder.Services;
var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>(c => c.BaseAddress = new Uri(Configuration["serviceUrls:ProductAPI"]));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
