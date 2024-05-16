using GestionVoyage.API.Context;
using GestionVoyage.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<GestionVoyageDbContext>(options => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=GestionVoyage;TrustServerCertificate=true;Integrated Security=True;MultipleActiveResultSets=true;"));

            services.AddTransient<ArriveRepository>();
            services.AddTransient<DepartRepository>();
        }
    }
}
