using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ngwmapp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<CustomerContext>(
    Options => Options.UseSqlite(builder.Configuration.GetConnectionString("CustomerContext"))
);
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultScheme = "Cookies";
    Options.DefaultChallengeScheme = "Microsoft";
})
.AddCookie()
.AddMicrosoftAccount(microsoftOptions =>
{
    microsoftOptions.ClientId = "53d6d096-d4d3-4cc8-933d-c0fb2339eb48";
    microsoftOptions.ClientSecret = "5c919eb0-a62d-4e13-a498-8f7869036ebc";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
