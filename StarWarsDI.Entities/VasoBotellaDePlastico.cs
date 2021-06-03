using StarWarsDI.Entities.Interfaces;
using System;

namespace StarWarsDI.Entities
{
    public class VasoBotellaDePlastico: IVasoBotellaPlastico, IVaso
    {
        public string Contenido { get; set; }

        public bool EstaLleno { 
            get {
                return !string.IsNullOrEmpty(Contenido);
            }
        }

        public bool MejorarBordesParaNoCortarse
        {
            get
            {
                return true;
            }
        }

        public override string ToString()
        {
            return $"{{contenido:{Contenido}, estaLleno:{EstaLleno}, type=BotellaDePlastico}}";
        }
    }
}
