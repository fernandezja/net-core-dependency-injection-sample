using Microsoft.Extensions.DependencyInjection;
using System;

namespace StarWarsDI.Core.Business.Tests
{
    public class UnitTest1
    {
        private ServiceProvider _serviceProvider;

        public UnitTest1()
        {
           var serviceCollection = new ServiceCollection();

            serviceCollection
                //.AddScoped<Core.Data.Interfaces.IBeerDrinkRepository, Core.Data.BeerDrinkRepository>()
                .AddTransient<Core.Data.Interfaces.ICokeDrinkRepository, Core.Data.CokeDrinkRepository>()
                //.AddTransient<Core.Data.Interfaces.IFernetDrinkRepository, Core.Data.FernetDrinkRepository>()

                .AddTransient<Core.Data.Interfaces.IBaseDrinkRepository, Core.Data.FernetDrinkRepository>()


                //.AddScoped<StarWarsDI.Business.Interfaces.IPartyBusiness, PartyBusiness>()
                .AddScoped<StarWarsDI.Business.Interfaces.IPartyBusiness, PartyGenericBusiness>()

                //.AddTransient<Entities.Interfaces.IVaso, Entities.Vaso>();
                .AddTransient<Entities.Interfaces.IVaso, Entities.VasoBotellaDePlastico>();

            _serviceProvider = serviceCollection.BuildServiceProvider();

        }


        [Fact]
        public void test1_vaso_IoC()
        {

            var vaso1 = _serviceProvider.GetService<Entities.Interfaces.IVaso>();
            var vaso2 = _serviceProvider.GetService<Entities.Interfaces.IVaso>();

            Assert.Equal("{contenido:, estaLleno:False, type=BotellaDePlastico}", vaso1.ToString());
            Assert.Equal("{contenido:, estaLleno:False, type=BotellaDePlastico}", vaso2.ToString());
            Assert.NotEqual(vaso1, vaso2);
        }

        [Fact]
        public async Task test1_party_IoC()
        {

            var party1 = _serviceProvider.GetService<StarWarsDI.Business.Interfaces.IPartyBusiness>();
            var vaso1 = _serviceProvider.GetService<Entities.Interfaces.IVaso>();

            //Assert.Equal("{contenido:, estaLleno:False}", vaso1.ToString());
            Assert.Equal("{contenido:, estaLleno:False, type=BotellaDePlastico}", vaso1.ToString());


            var result = await party1.ServirAsync(vaso1);

            //Assert.Equal("{contenido:a Beer!, estaLleno:True}", vaso1.ToString());
            //Assert.Equal("{contenido:a Fernet with a Coke!, estaLleno:True}", vaso1.ToString());

            Assert.Equal("{contenido:a Fernet with a Coke!!, estaLleno:True, type=BotellaDePlastico}", vaso1.ToString());

        }
    }
}
