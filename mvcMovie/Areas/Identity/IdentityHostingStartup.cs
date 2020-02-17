using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mvcMovie.Areas.Identity.Data;
using mvcMovie.Models;

[assembly: HostingStartup(typeof(mvcMovie.Areas.Identity.IdentityHostingStartup))]
namespace mvcMovie.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<mvcMovieContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("mvcMovieContext")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<mvcMovieContext>();
            });
        }
    }
}