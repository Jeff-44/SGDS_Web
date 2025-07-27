using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using Infrastructure.DataAccess;
using Infrastructure.Identity;
using Infrastructure.Implementations.Repositories;
using Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGDS_Web.Mappings;
using SGDS_Web.Utils;
//using SGDS_Web.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<SGDSDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SGDSDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddAutoMapper(typeof(DonneurVMMappingProfile));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDonneurRepository, DonneurRepository>();

builder.Services.AddTransient<IEmailSender, EmailSender>();

//Services
builder.Services.AddScoped<IDonneurService, DonneurService>();
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
