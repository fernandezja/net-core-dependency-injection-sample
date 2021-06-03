using StarWarsDI.Business.Interfaces;
using StarWarsDI.Core.Data.Interfaces;
using StarWarsDI.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Business
{
    public class PartyGenericBusiness : IPartyBusiness
    {
        private IBaseDrinkRepository _drinkRepository;

        public PartyGenericBusiness(IBaseDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public void Dispose()
        {
            
        }

        public async Task<bool> ServirAsync(IVaso vaso)
        {
            vaso.Contenido = await _drinkRepository.GetAsync();

            return true;
        }
    }
}
