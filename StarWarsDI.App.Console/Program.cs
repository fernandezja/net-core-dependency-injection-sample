using System;
using Microsoft.Extensions.DependencyInjection;
using StarWarsDI.Entities.Interfaces;
using StarWarsDI.Entities;
using Microsoft.Extensions.Logging;

namespace StarWarsDI.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuracion DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<Core.Data.Interfaces.IBeerDrinkRepository, Core.Data.BeerDrinkRepository>()
                .AddTransient<Entities.Interfaces.IVaso, Entities.Vaso>()
                .AddTransient<Business.Interfaces.IPartyBusiness, Core.Business.PartyBusiness>()
                .BuildServiceProvider();

            //Configuracion log para console
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug)
                .AddDebug();

            //IoC
            var logger = serviceProvider
                            .GetService<ILoggerFactory>()
                            .CreateLogger<Program>();

            logger.LogInformation("StarWars! DI");

            //IoC
            var party = serviceProvider.GetService<Business.Interfaces.IPartyBusiness>();
            var vaso = serviceProvider.GetService<Entities.Interfaces.IVaso>();

            party.ServirAsync(vaso);
            logger.LogInformation($"vaso ={vaso}");


            #region IoC Using
            //IoC: Party
            using (var party2 = serviceProvider.GetService<Business.Interfaces.IPartyBusiness>())
            {
                var vaso2 = serviceProvider.GetService<Entities.Interfaces.IVaso>();
                logger.LogInformation($"vaso2 = {vaso2}");
            }
            #endregion


            

            

            System.Console.ReadKey();
        }
    }
}