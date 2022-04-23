using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.ValueObjects;

namespace Ventas.Domain.Modelo.Ventas
{
    public class Venta : AggregateRoot<Guid>
    {
        public Guid ClienteId { get; private set; }
        public DateTime fechaReserva { get; private set; }
        public DateTime fechaPago { get; private set; }
        public string numeroTicket { get; private set; }
        public bool tipo { get; private set; }
        public string pasajero { get; private set; }



    }
}
