using StarWarsDI.Entities.Interfaces;
using System.Collections.Generic;

namespace StarWarsDI.Business.Interfaces
{
    public interface IChatBusiness
    {
        List<IMensaje> GetMensajes();
    }
}