using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.EntityFrameworkCore;
using CarInsuranceManage.Database;
using Microsoft.AspNetCore.Authentication.Google;
using CarInsuranceManage.Configuration;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddSingleton<TwilioSettings>(builder.Configuration.GetSection("Twilio").Get<TwilioSettings>());

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add routing configuration to make URLs lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Cấu hình DbContext để sử dụng MySQL
builder.Services.AddDbContext<CarInsuranceDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 33))));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;  // Change this to FacebookDefaults.AuthenticationScheme for default if necessary.
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
})
.AddFacebook(options =>
{
    options.AppId = builder.Configuration["Facebook:AppId"];
    options.AppSecret = builder.Configuration["Facebook:AppSecret"];
});


var app = builder.Build();

// Ensure database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarInsuranceDbContext>();
    try
    {
        dbContext.Database.Migrate(); // Apply migrations and seed data
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // Enable serving static files like images, CSS, and JS

app.UseRouting();

// Configure authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Set up the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();