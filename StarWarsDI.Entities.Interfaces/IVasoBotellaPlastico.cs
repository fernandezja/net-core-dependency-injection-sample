using System;

namespace StarWarsDI.Entities.Interfaces
{
    public interface IVasoBotellaPlastico: IVaso
    {
        bool MejorarBordesParaNoCortarse { get; }

    }
}
