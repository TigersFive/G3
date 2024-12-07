using Microsoft.EntityFrameworkCore;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC vào container
builder.Services.AddControllersWithViews();

// Thêm cấu hình routing để URL luôn viết chữ thường
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Cấu hình DbContext để sử dụng MySQL
builder.Services.AddDbContext<CarInsuranceDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 33))));

// Cấu hình xác thực Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

// Xây dựng ứng dụng
var app = builder.Build();

// Đảm bảo database đã được tạo và dữ liệu mẫu được thêm vào
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarInsuranceDbContext>();
    try
    {
        dbContext.Database.Migrate(); // Áp dụng migrations và seed data
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // Cấu hình cho phép phục vụ các tài nguyên tĩnh như hình ảnh, CSS, JS

app.UseRouting();

// Cấu hình xác thực và ủy quyền
app.UseAuthentication();
app.UseAuthorization();

// Cấu hình Route cho các controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Chạy ứng dụng
app.Run();
