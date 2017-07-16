using System;
using System.Threading.Tasks;
using StarWarsDI.Entities.Interfaces;

namespace StarWarsDI.Business.Interfaces
{
    public interface IPartyBusiness: IDisposable
    {
        Task<bool> ServirAsync(IVaso vaso);
    }
}
