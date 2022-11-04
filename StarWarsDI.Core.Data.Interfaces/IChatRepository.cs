using StarWarsDI.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Data.Interfaces
{
    public interface IChatRepository
    {
        List<IMensaje> GetMensajesFromDb();
    }
}
