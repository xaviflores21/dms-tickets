using Reservas.Domain.Model.Reserva;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Evento
{
    public record ReservaCreada : DomainEvent
    {
        public Guid ReservaId { get; }
        public NumReservaValue NroReserva { get; private set; }
        public string Tipo_Pago { get; private set; }
        public Guid num_ticket_reserva { get; private set; }
        public Guid num_ticket_venta { get; private set; }
        public PrecioValue MontoTotal { get; private set; }
        public PrecioValue Deuda { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime Fecha { get; private set; }
        public string estado1 { get; private set; }
        public string estado2 { get; private set; }

        public ReservaCreada(Guid pedidoId,
            string nroPedido) : base(DateTime.Now)
        {
            ReservaId = pedidoId;
            NroReserva = nroPedido;

        }
    }
}
