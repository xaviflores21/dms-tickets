 
using Reservas.Domain.Model.Reserva;

namespace Reservas.Domain.Factories
{
    public class ReservaFactory : IReservaFactory
    {
        public ReservaTicket Create(string nroPedido)
        {
            return new ReservaTicket(nroPedido);
        }
    }
}
