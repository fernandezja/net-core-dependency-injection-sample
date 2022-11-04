using System;

namespace StarWarsDI.Entities.Interfaces
{
    public interface IMensaje
    {
        string Contenido { get; set; }
        DateTime Fecha { get; set; }
        int MensajeId { get; set; }
        int SalaId { get; set; }
        int UsuarioId { get; set; }
    }
}