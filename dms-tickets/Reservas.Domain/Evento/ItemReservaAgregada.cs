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
        public Guid VueloId { get; }
        public Guid NumVuelo { get; }
        public string TipoAsiento { get; }
        public CantidadValue Cantidad { get; }
        public PrecioValue Precio { get; }

        public ItemReservaAgregada(Guid vueloId_, Guid numVuelo_, string tAsiento_, CantidadValue cantidad, PrecioValue precio) : base(DateTime.Now)
        {
            VueloId = vueloId_;
            NumVuelo = numVuelo_;
            TipoAsiento = tAsiento_;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
