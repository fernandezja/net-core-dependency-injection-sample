using StarWarsDI.Core.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Data
{
    public class BeerDrinkRepository : IBeerDrinkRepository
    {
        #region IBeerDrinkRepository
        public async Task<string> GetAsync()
        {
            return await Task.FromResult("a Beer!");
        }

        #endregion

    }
}
