using Reservas.Domain.Model.ValueObjects;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Evento
{
    public record ItemReservaAgregada : DomainEvent
    {
        public Guid ProductoId { get; }
        public PrecioValue Precio { get; }
        public CantidadValue Cantidad { get; }

        public ItemReservaAgregada(Guid productoId, PrecioValue precio, CantidadValue cantidad) : base(DateTime.Now)
        {
            ProductoId = productoId;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
