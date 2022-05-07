using Reservas.Domain.Model.Reserva;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Evento
{
    public record ReservaCreada : DomainEvent
    {
        public Guid PedidoId { get; }
        public string NroPedido { get; }

        public ReservaCreada(Guid pedidoId,
            string nroPedido) : base(DateTime.Now)
        {
            PedidoId = pedidoId;
            NroPedido = nroPedido;

        }
    }
}
