using System;
using System.Threading.Tasks;
using StarWarsDI.Business.Interfaces;
using StarWarsDI.Entities.Interfaces;
using StarWarsDI.Core.Data.Interfaces;

namespace StarWarsDI.Core.Business
{
    public class PartyBusiness : IPartyBusiness
    {
        public IBeerDrinkRepository BeerDrinkRepository { get; set; }
        public ICokeDrinkRepository CokeDrinkRepository { get; set; }
        public IFernetDrinkRepository FernetDrinkRepository { get; set; }

        public PartyBusiness(IBeerDrinkRepository beerDrinkRepository,
                            ICokeDrinkRepository cokeDrinkRepository,
                            IFernetDrinkRepository fernetDrinkRepository)
        {
            BeerDrinkRepository = beerDrinkRepository;
            CokeDrinkRepository = cokeDrinkRepository;
            FernetDrinkRepository = fernetDrinkRepository;
        }

        #region IPartyBusiness
        public async Task<bool> ServirAsync(IVaso vaso)
        {
            var drink = await FernetDrinkRepository.GetAsync();

            vaso.Contenido = ($"Drink {drink}");

            return await Task.FromResult(true);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            
        }
        #endregion
    }
}
