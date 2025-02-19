using DataContext.DB_Context;
using DataContext.Repository.Dapper;
using Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineAdmissionPortal.Data;
using OnlineAdmissionPortal.Services.Account;
using OnlineAdmissionPortal.Services.Institution;
using OnlineAdmissionPortal.Services.Student;

var builder = WebApplication.CreateBuilder(args);

// Disable automatic authentication for IIS
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});

// Add services to the container
builder.Services.AddScoped<IDapperRepository, DapperRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IInstitutionService, InstitutionService>();

// Get the connection string
var connectionString = builder.Configuration.GetConnectionString("OnlineAdmissionConnectionString")
    ?? throw new InvalidOperationException("Connection string 'OnlineAdmissionConnectionString' not found.");

// Register ApplicationDbContext for EF Core (Use this for migrations)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register OnlineAdmissionDbContext for raw SQL queries (Dapper)
builder.Services.AddScoped<OnlineAdmissionDbContext>();

// Identity configuration (Use ApplicationDbContext for Identity)
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add Controllers and Views
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configure session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.OnlineAdmissionPortal";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    options.LoginPath = "/Identity/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// Configure default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Users}/{id?}");
app.MapRazorPages();

app.Run();
