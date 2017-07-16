using StarWarsDI.Entities.Interfaces;
using System;

namespace StarWarsDI.Entities
{
    public class Vaso: IVaso
    {
        public string Contenido { get; set; }

        public bool EstaLleno { 
            get {
                return !string.IsNullOrEmpty(Contenido);
            }
        }

        public override string ToString()
        {
            return $"{{contenido:{Contenido}, estaLleno:{EstaLleno}}}";
        }
    }
}
