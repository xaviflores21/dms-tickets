 
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;

namespace Reservas.Domain.Factories
{
    public interface IVueloFactory
    {
        Vuelos Create(Nro_Vuelo _Numero_, string _Tipo_Asiento_, PrecioValue _Cantidad_, PrecioValue _Precio_, Pasaje _Pasaje_);
    }
}
