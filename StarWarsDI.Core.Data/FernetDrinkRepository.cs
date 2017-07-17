using StarWarsDI.Core.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Data
{
    public class FernetDrinkRepository : IFernetDrinkRepository
    {
        public ICokeDrinkRepository CokeDrinkRepository { get; set; }

        public FernetDrinkRepository(ICokeDrinkRepository cokeDrinkRepository)
        {
            CokeDrinkRepository = cokeDrinkRepository;
        }

        #region IFernetDrinkRepository
        public async Task<string> GetAsync()
        {
            var coke = await CokeDrinkRepository.GetAsync();
            return await Task.FromResult($"a Fernet with {coke}!");
        }

        #endregion

    }
}
