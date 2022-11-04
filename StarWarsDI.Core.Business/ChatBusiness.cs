using StarWarsDI.Business.Interfaces;
using StarWarsDI.Core.Data.Interfaces;
using StarWarsDI.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace StarWarsDI.Core.Business
{
    public class ChatBusiness : IChatBusiness
    {
        private IChatRepository _chatRepository;

        public ChatBusiness(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public List<IMensaje> GetMensajes()
        {
            var lista = _chatRepository.GetMensajesFromDb();
            return lista;
        }
    }
}