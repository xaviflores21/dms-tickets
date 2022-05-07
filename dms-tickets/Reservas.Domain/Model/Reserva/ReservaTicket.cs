using Reservas.Domain.Evento;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reserva
{
    public class ReservaTicket : AggregateRoot<Guid>
    {
        public Guid ClienteId { get; private set; }
        public Nro_Vuelo NroPedido { get; private set; }
        public PrecioValue Total { get; private set; }

        private readonly ICollection<Reserva_Detalle> _detalle;

        public IReadOnlyCollection<Reserva_Detalle> Detalle
        {
            get
            {
                return new ReadOnlyCollection<Reserva_Detalle>(_detalle.ToList());
            }
        }

        private ReservaTicket() { }

        internal ReservaTicket(string nroPedido)
        {
            Id = Guid.NewGuid();
            NroPedido = nroPedido;
            Total = new PrecioValue(0m);
            _detalle = new List<Reserva_Detalle>();
        }

        public void AgregarItem(Guid productoId, int cantidad, decimal precio, string instrucciones)
        {
            var detallePedido = _detalle.FirstOrDefault(x => x.ProductoId == productoId);
            if (detallePedido is null)
            {
                detallePedido = new Reserva_Detalle(productoId, instrucciones, cantidad, precio);
                _detalle.Add(detallePedido);
            }
            else
            {
                detallePedido.ModificarPedido(cantidad, precio);
            }

            Total = Total + detallePedido.SubTotal;

            AddDomainEvent(new ItemReservaAgregada(productoId, precio, cantidad));
        }

        public void ConsolidarPedido()
        {
            var evento = new ReservaCreada(Id, NroPedido);
            AddDomainEvent(evento);
        }

    }
}
