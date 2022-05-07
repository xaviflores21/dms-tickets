 
using Reservas.Domain.Model.Reservas;

namespace Reservas.Domain.Factories
{
    public class ReservaFactory : IReservaFactory
    {
        public Reserva Create(string nroPedido)
        {
            return new Reserva(nroPedido);
        }
    }
}
