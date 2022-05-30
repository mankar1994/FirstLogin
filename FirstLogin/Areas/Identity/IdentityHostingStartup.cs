using System;
using FirstLogin.Areas.Identity.Data;
using FirstLogin.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FirstLogin.Areas.Identity.IdentityHostingStartup))]
namespace FirstLogin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FirstLoginDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FirstLoginDbContextConnection")));

                services.AddDefaultIdentity<LoginUser>(options =>
                {

                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<FirstLoginDbContext>();
            });
        }
    }
}