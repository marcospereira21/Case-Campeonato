using Campeonato.Data;
using Campeonato.Model;
using Campeonato.Resourses;
using Campeonato.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Campeonato.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=Campeonato.db"));
            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<IFileHandler, FileHandler>();
            services.AddScoped<IJsonService, JsonService>();
            services.AddScoped<IStringHandler, StringHandler>();
            services.AddScoped<IMessageModel, MessageModel>();
            services.AddScoped<ICampeonatoService, CampeonatoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
