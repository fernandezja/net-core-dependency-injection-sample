using System;
using System.Threading.Tasks;
using StarWarsDI.Business.Interfaces;
using StarWarsDI.Entities.Interfaces;

namespace StarWarsDI.Core.Business
{
    public class PartyBusiness : IPartyBusiness
    {
       

        #region IPartyBusiness
        public Task<bool> ServirAsync(IVaso vaso)
            {
                vaso.Contenido = "demo";
                return Task.FromResult(true);
            }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            
        }
        #endregion
    }
}
