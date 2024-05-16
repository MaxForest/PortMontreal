using GestionVoyage.API.Context;
using GestionVoyage.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API
{
    public class Startup(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<GestionVoyageDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("gestionVoyageConnection")));

            services.AddTransient<ArriveRepository>();
            services.AddTransient<DepartRepository>();
        }
    }
}
