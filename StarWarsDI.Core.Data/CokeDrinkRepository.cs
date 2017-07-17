using StarWarsDI.Core.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Data
{
    public class CokeDrinkRepository : ICokeDrinkRepository
    {
        #region ICokeDrinkRepository
        public async Task<string> GetAsync()
        {
            return await Task.FromResult("a Coke!");
        }

        #endregion

    }
}
