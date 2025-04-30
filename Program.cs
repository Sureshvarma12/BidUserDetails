using BidUser.Models;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BidUser.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BidUser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Register DbContext with SQL Server
            builder.Services.AddDbContext<BidUserContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Disable account confirmation requirement on login
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;

                // Optional: Customize password settings, etc.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
            })

     .AddEntityFrameworkStores<BidUserContext>()
      .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";  // Adjusted to reflect your areas folder
            });
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IEmailSender,EmailSender>();

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BidUserContext>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.MapRazorPages();
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Identity/Account/Login");
                return Task.CompletedTask;
            });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
