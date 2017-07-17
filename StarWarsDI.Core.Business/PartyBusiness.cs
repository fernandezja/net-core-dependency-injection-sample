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

        public PartyBusiness(IBeerDrinkRepository beerDrinkRepository)
        {
            BeerDrinkRepository = beerDrinkRepository;
        }

        #region IPartyBusiness
        public async Task<bool> ServirAsync(IVaso vaso)
        {
            var drink = await BeerDrinkRepository.GetAsync();

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
