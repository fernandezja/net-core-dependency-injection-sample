using System;
using Microsoft.Extensions.DependencyInjection;
using StarWarsDI.Entities.Interfaces;
using StarWarsDI.Entities;
using Microsoft.Extensions.Logging;
using StarWarsDI.Core.Business;
using System.Threading.Tasks;

namespace StarWarsDI.App.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //Configuracion DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<Core.Data.Interfaces.IBeerDrinkRepository, Core.Data.BeerDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.ICokeDrinkRepository, Core.Data.CokeDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.IFernetDrinkRepository, Core.Data.FernetDrinkRepository>()
                .AddScoped<Entities.Interfaces.IVaso, Entities.Vaso>()
                .AddTransient<Entities.Interfaces.IVasoBotellaPlastico, Entities.VasoBotellaDePlastico>()
                .AddTransient<Business.Interfaces.IPartyBusiness, Core.Business.PartyBusiness>()
                .BuildServiceProvider();



            //IoC
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            
            var vaso3 = serviceProvider.GetRequiredService<IVasoBotellaPlastico>();
            var seMejoro = vaso3.MejorarBordesParaNoCortarse;

            var vaso4 = serviceProvider.GetRequiredService<IVaso>();
            vaso4.Contenido = "Demo water";

            var vaso5 = serviceProvider.GetRequiredService<IVaso>();
            var demo = vaso5.Contenido;

            logger.LogInformation("StarWars! DI");

            //IoC
            var party = serviceProvider.GetService<Business.Interfaces.IPartyBusiness>();
            var vaso = serviceProvider.GetService<Entities.Interfaces.IVaso>();

            await party.ServirAsync(vaso);
            logger.LogInformation($"vaso ={vaso}");


            #region IoC Using
            //IoC: Party
            using (var party2 = serviceProvider.GetService<Business.Interfaces.IPartyBusiness>())
            {
                var vaso2 = serviceProvider.GetService<Entities.Interfaces.IVaso>();
                logger.LogInformation($"vaso2 = {vaso2}");
            }
            #endregion


            /*
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<Core.Data.Interfaces.IBeerDrinkRepository, Core.Data.BeerDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.ICokeDrinkRepository, Core.Data.CokeDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.IFernetDrinkRepository, Core.Data.FernetDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.IBaseDrinkRepository, Core.Data.CokeDrinkRepository>()
                .AddScoped<PartyGenericBusiness>()
                .AddTransient<PartyBusiness>()
                .AddTransient<IVaso, VasoBotellaDePlastico>()
                .BuildServiceProvider();


            serviceProvider
               .GetService<ILoggerFactory>()
               .AddConsole(LogLevel.Debug)
               .AddDebug();

            //IoC
            var logger = serviceProvider
                            .GetService<ILoggerFactory>()
                            .CreateLogger<Program>();


            var party1 = serviceProvider.GetService<PartyGenericBusiness>();
            var party2 = serviceProvider.GetService<PartyGenericBusiness>();
            var vaso = serviceProvider.GetService<IVaso>();

            var demo = party.ToString();

            await party.ServirAsync(vaso);

            var demo2 = vaso.ToString();
            */





            System.Console.ReadKey();
        }
    }
}