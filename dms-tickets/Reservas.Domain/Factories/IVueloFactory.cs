 
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using System;

namespace Reservas.Domain.Factories
{
    public interface IVueloFactory
    {
        Vuelo Create(Nro_Vuelo _Numero_, string _Tipo_Asiento_, int _Cantidad_, decimal _Precio_, Guid _Pasaje_);
    }
}
