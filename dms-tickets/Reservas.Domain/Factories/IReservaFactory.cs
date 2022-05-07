 
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using System;

namespace Reservas.Domain.Factories
{
    public interface IReservaFactory
    {
        Reserva Create(string nroPedido);
    }
}
