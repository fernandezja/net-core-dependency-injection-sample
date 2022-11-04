using StarWarsDI.Core.Data.Interfaces;
using StarWarsDI.Entities;
using StarWarsDI.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsDI.Core.Data
{
    public class ChatSlackRepository : IChatRepository
    {
        public List<IMensaje> GetMensajesFromDb()
        {
            var lista = new List<IMensaje>();

            //Obtener info de la DB
            for (int i = 0; i < 10; i++)
            {
                lista.Add(new Mensaje(i * 10, i, " [Slack]"));
            }

            return lista;
        }
    }
}
