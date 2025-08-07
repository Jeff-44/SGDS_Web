using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using Infrastructure.DataAccess;
using Infrastructure.Identity;
using Infrastructure.Implementations.Repositories;
using Infrastructure.Implementations.Services;
using Infrastructure.Mappings;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SGDS_Web.Mappings;

//using SGDS_Web.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<SGDSDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SGDSDbContext>()
    .AddDefaultTokenProviders();
//Email configuration via user secrets for development
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

//Email configuration via environment variables for production
//builder.Services.Configure<EmailSettings>(opts =>
//{
//    opts.Host = Environment.GetEnvironmentVariable("EMAIL__HOST") ?? throw new Exception("Missing SMTP host");
//    opts.Port = int.Parse(Environment.GetEnvironmentVariable("EMAIL__PORT") ?? "587");
//    opts.Username = Environment.GetEnvironmentVariable("EMAIL__USER") ?? throw new Exception("Missing SMTP user");
//    opts.Password = Environment.GetEnvironmentVariable("EMAIL__PASS") ?? throw new Exception("Missing SMTP password");
//    opts.UseStartTls = true;   
//    opts.From = Environment.GetEnvironmentVariable("EMAIL__FROM") ?? opts.Username;
//});

builder.Services.AddTransient<IEmailSender, MailKitEmailSender>();

//Web Mappings
builder.Services.AddAutoMapper(cfg => {}, typeof(DonneurVMMappingProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(DossierVMMappingProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CreerModifierDossierProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CollecteVMProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CreerModifierCollecteProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CentreVMProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CreerModifierCentreProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(DonVMProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CreerModifierDonProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(EditUserVMProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(UserVMProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(CreerModifierRoleProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(RoleVMProfile));

//Infrastructure Mappings
builder.Services.AddAutoMapper(cfg => {}, typeof(DomainUserProfile));
builder.Services.AddAutoMapper(cfg => {}, typeof(DomainRoleProfile));


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDonneurRepository, DonneurRepository>();
builder.Services.AddScoped<IDossierRepository, DossierRepository>();
builder.Services.AddScoped<ICollecteRepository, CollecteRepository>();
builder.Services.AddScoped<ICentreRepository, CentreRepository>();
builder.Services.AddScoped<IDonRepository, DonRepository>();

//Reference data repositories
builder.Services.AddScoped<ICommuneRepository, CommuneRepository>();
builder.Services.AddScoped<IArrondissementRepository, ArrondissementRepository>();
builder.Services.AddScoped<IDepartementRepository, DepartementRepository>();

//Utils
builder.Services.AddTransient<IEmailSender, MailKitEmailSender>();

//Services
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IDonneurService, DonneurService>();
builder.Services.AddScoped<IDossierService, DossierService>();
builder.Services.AddScoped<ICollecteService, CollecteService>();
builder.Services.AddScoped<ICentreService, CentreService>();
builder.Services.AddScoped<IDonService, DonService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();

//Reference data services
builder.Services.AddScoped<ICommuneService, CommuneService>();
builder.Services.AddScoped<IArrondissementService, ArrondissementService>();
builder.Services.AddScoped<IDepartementService, DepartementService>();

// Other services
builder.Services.AddScoped<IEligibilityService, EligibilityService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{ 
    var context = scope.ServiceProvider.GetRequiredService<SGDSDbContext>();
    context.Database.Migrate();
}
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
