using System;
using koichanCoreUserTest.Areas.Identity.Data;
using koichanCoreUserTest.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(koichanCoreUserTest.Areas.Identity.IdentityHostingStartup))]
namespace koichanCoreUserTest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<koichanCoreUserTestDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("koichanCoreUserTestDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                    .AddEntityFrameworkStores<koichanCoreUserTestDBContext>();
            });
        }
    }
}