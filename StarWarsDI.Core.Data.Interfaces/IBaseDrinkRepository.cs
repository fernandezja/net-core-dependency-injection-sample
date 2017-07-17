using System;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Data.Interfaces
{
    public interface IBaseDrinkRepository
    {
        Task<string> GetAsync();
    }
}
