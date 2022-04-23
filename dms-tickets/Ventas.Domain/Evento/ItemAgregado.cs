using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.ValueObjects;

namespace Ventas.Domain.Evento
{
    public record ItemAgregado : DomainEvent
    {
        public Guid VueloId { get; }
        public PrecioValue Precio { get; }
        public CantidadValue Cantidad { get; }

        public ItemAgregado(Guid _VueloId, PrecioValue precio, CantidadValue cantidad) : base(DateTime.Now)
        {
            VueloId = _VueloId;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
