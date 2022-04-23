using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Evento
{
    public record VentaCreada : DomainEvent
    {
        

        public Guid VentaId { get; }
        public string NumeroTicket { get; }

        public VentaCreada(Guid _ventaId, string _numeroTicket) : base (DateTime.Now)
        {
            VentaId = _ventaId;
            NumeroTicket = _numeroTicket;
        }
    }
}
