 
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;

namespace Reservas.Domain.Factories
{
    public class VueloFactory : IVueloFactory
    {
        public Vuelos Create(Nro_Vuelo _Numero_, string _Tipo_Asiento_, PrecioValue _Cantidad_, PrecioValue _Precio_, Pasaje _Pasaje_)
        {
            return new Vuelos(_Numero_, _Tipo_Asiento_, _Cantidad_, _Precio_,_Pasaje_);
        }
    }
}
