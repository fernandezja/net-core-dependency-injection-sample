using System;
using Microsoft.Extensions.DependencyInjection;
using StarWarsDI.Entities.Interfaces;
using StarWarsDI.Entities;
using Microsoft.Extensions.Logging;
using StarWarsDI.Core.Business;
using System.Threading.Tasks;
using StarWarsDI.Business.Interfaces;

namespace StarWarsDI.App.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Demo2Chat();

            await DemoAsync();

            System.Console.ReadKey();
        }

        private static void Demo2Chat()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<Core.Data.Interfaces.IChatRepository, Core.Data.ChatSlackRepository>()
                .AddTransient<Business.Interfaces.IChatBusiness, Core.Business.ChatBusiness>()
                .BuildServiceProvider();


            var chatBusiness = serviceProvider.GetRequiredService<Business.Interfaces.IChatBusiness>();

            Chat(chatBusiness);
        }

        static void Chat(IChatBusiness chatBusiness)
        {

            //chatBusiness = new ChatDiscordBusiness(new ...Repository());

            var mensajes = chatBusiness.GetMensajes();

            System.Console.WriteLine($"Mensajes {mensajes.Count}");

            foreach (var m in mensajes)
            {
                System.Console.WriteLine($" > {m.Contenido} (Usuario {m.UsuarioId})");
            }
        }

        static async Task DemoAsync()
        {

            //Configuracion DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<Core.Data.Interfaces.IBeerDrinkRepository, Core.Data.BeerDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.ICokeDrinkRepository, Core.Data.CokeDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.IFernetDrinkRepository, Core.Data.FernetDrinkRepository>()
                .AddScoped<Entities.Interfaces.IVaso, Entities.VasoBotellaDePlastico>()
                //.AddTransient<Entities.Interfaces.IVasoBotellaPlastico, Entities.VasoBotellaDePlastico>()
                .AddTransient<Business.Interfaces.IPartyBusiness, Core.Business.PartyBusiness>()
                .BuildServiceProvider();



            //IoC
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            //var vaso3 = serviceProvider.GetRequiredService<IVasoBotellaPlastico>();
            //var seMejoro = vaso3.MejorarBordesParaNoCortarse;

            //var vaso4 = serviceProvider.GetRequiredService<IVaso>();
            //vaso4.Contenido = "Demo water";

            //var vaso5 = serviceProvider.GetRequiredService<IVaso>();
            //var demo = vaso5.Contenido;

            logger.LogInformation("StarWars! DI");
            System.Console.WriteLine("StarWars! DI");

            //IoC
            var party = serviceProvider.GetService<Business.Interfaces.IPartyBusiness>();
            var vaso = serviceProvider.GetService<Entities.Interfaces.IVaso>();

            //await party.ServirAsync(vaso);
            logger.LogInformation($"vaso ={vaso}");
            System.Console.WriteLine($"vaso ={vaso}");

            await party.ServirAsync(vaso);

            //await party.ServirAsync(vaso);
            logger.LogInformation($"vaso ={vaso}");
            System.Console.WriteLine($"vaso ={vaso}");


            //#region IoC Using
            ////IoC: Party
            //using (var party2 = serviceProvider.GetService<Business.Interfaces.IPartyBusiness>())
            //{
            //    var vaso2 = serviceProvider.GetService<Entities.Interfaces.IVaso>();
            //    logger.LogInformation($"vaso2 = {vaso2}");
            //}
            //#endregion


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


        }
    }
}