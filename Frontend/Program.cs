using Frontend.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllersWithViews();
builder.Services
    .Configure<ApiConfigurations>(builder.Configuration.GetSection("ApiConfigurations"))
    .AddHttpContextAccessor()
    .AddScoped<IAuthenticatService, AuthenticationService>()
    .AddSession(config =>
    {
        config.IdleTimeout = TimeSpan.FromMinutes(30);
        config.Cookie.Name = "ASPNET_Session";
        config.Cookie.HttpOnly = true;

    });
builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = "/accounts/Login";
                    options.LogoutPath = "/accounts/signout";
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
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
