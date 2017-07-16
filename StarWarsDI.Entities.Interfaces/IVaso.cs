using System;

namespace StarWarsDI.Entities.Interfaces
{
    public interface IVaso
    {
        string Contenido { get; set; }
        bool EstaLleno { get; }

    }
}
