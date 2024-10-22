using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using WebApplication4.PhanTrang;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var connectionString = builder.Configuration.GetConnectionString("QlbanVaLiContext");
builder.Services.AddDbContext<QlbanVaLiContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ILoaiSpRepository,LoaiSpRepository>();
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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Add the following code to redirect to the login page when accessing the home page


app.Run();

