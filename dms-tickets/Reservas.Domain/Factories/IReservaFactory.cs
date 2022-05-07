 
using Reservas.Domain.Model.Reserva;
using Reservas.Domain.ValueObjects;
using System;

namespace Reservas.Domain.Factories
{
    public interface IReservaFactory
    {
        ReservaTicket Create(string nroPedido);
    }
}
