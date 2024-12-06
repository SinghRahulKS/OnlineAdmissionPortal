using DataContext.Repository.Dapper;
using Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineAdmissionPortal.Data;
using OnlineAdmissionPortal.Services.Account;
using OnlineAdmissionPortal.Services.Institution;
using OnlineAdmissionPortal.Services.Student;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});
// Add services to the container.
builder.Services.AddScoped<IDapperRepository, DapperRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IInstitutionService, InstitutionService>();
var connectionString = builder.Configuration.GetConnectionString("OnlineAdmissionConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<OnlineAdmissionPortalContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<OnlineAdmissionPortalContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.OnlineAdmissionPortal";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    options.LoginPath = "/Identity/Account/Login";
});

builder.Services.AddRazorPages();
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
app.UseAuthentication(); // if using authentication
app.UseAuthorization();
// Add session before routing
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Users}/{id?}");
app.MapRazorPages();

app.Run();
