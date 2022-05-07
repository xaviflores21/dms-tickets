 
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using System;

namespace Reservas.Domain.Factories
{
    public class VueloFactory : IVueloFactory
    {
        public Vuelo Create(Nro_Vuelo _Numero_, string _Tipo_Asiento_, int _Cantidad_, decimal _Precio_, Guid _Pasaje_)
        {
            return new Vuelo(_Numero_, _Tipo_Asiento_, _Cantidad_, _Precio_,_Pasaje_);
        }
    }
}
