using StarWarsDI.Entities.Interfaces;
using System;

namespace StarWarsDI.Entities
{
    public class Mensaje : IMensaje
    {
        public int MensajeId { get; set; }
        public string Contenido { get; set; }
        public int SalaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        public Mensaje(int mensajeId, int usuarioId)
        {
            MensajeId = mensajeId;
            Contenido = $"Mensaje {mensajeId}";
            SalaId = 1;
            UsuarioId = usuarioId;
            Fecha = DateTime.Now;

        }

        public Mensaje(int mensajeId, int usuarioId, string prefijo)
        {
            MensajeId = mensajeId;
            Contenido = $"{prefijo} Mensaje {mensajeId}";
            SalaId = 1;
            UsuarioId = usuarioId;
            Fecha = DateTime.Now;

        }

    }
}