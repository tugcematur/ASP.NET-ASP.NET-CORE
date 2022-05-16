//using KatmanliMimari.Dal;
//using KatmanliMimari.Dal.Users;
//using KatmanliMimari.Repos.Abstracts;
using KatmanliMimari.Repos.Contretes;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.UI.Data;
using KatmanliMimari.Uow;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KatmanliMimari.Repos.Abstracts;
using KatmanliMimari.UI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");




builder.Services.AddDbContext<ApplicationDbContext>(options =>  // .UI ->Data->Migrations içinde 
    options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<Context>(options =>    //Kendi Context imizi yazıcaz   // using KatmanliMimari.Dal; eklendi 
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<KatmanliDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<IProductRepos, ProductRepos>();
builder.Services.AddScoped<IAspNetRoleRepos, AspNetRoleRepos>();
builder.Services.AddScoped<IAspNetUserRepos, AspNetUserRepos>();

builder.Services.AddScoped<AspNetUserModel>();
builder.Services.AddScoped<AspNetRoleModel>();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin"));
});




builder.Services.Configure<IdentityOptions>(options =>    // Introduction to Identity Core 6
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});





builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
