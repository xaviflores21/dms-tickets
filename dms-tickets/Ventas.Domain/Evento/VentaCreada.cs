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
        

        public Guid Id { get; }
        public string NumeroVenta { get; }

        public VentaCreada(DateTime occuredOn) : base(occuredOn)
        {

        }
    
    }
}
