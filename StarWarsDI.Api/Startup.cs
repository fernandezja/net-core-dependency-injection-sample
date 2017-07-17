using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StarWarsDI.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Configuracion DI
            services.AddLogging();
            services.AddTransient<Core.Data.Interfaces.IBeerDrinkRepository, Core.Data.BeerDrinkRepository>();
            services.AddTransient<Core.Data.Interfaces.ICokeDrinkRepository, Core.Data.CokeDrinkRepository>();
            services.AddTransient<Core.Data.Interfaces.IFernetDrinkRepository, Core.Data.FernetDrinkRepository>();
            services.AddTransient<Entities.Interfaces.IVaso, Entities.Vaso>();
            services.AddTransient<Business.Interfaces.IPartyBusiness, Core.Business.PartyBusiness>();
          

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
