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
        public Guid PasajeroId { get; private set; }
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

        private readonly ICollection<Reserva_Detalle> _detalle;

        public IReadOnlyCollection<Reserva_Detalle> Detalle
        {
            get
            {
                return new ReadOnlyCollection<Reserva_Detalle>(_detalle.ToList());
            }
        }

        private ReservaTicket() { }

        public string tipoPago(int tipo_pago)
        {
            if(tipo_pago != 0)
            {
                num_ticket_venta = Guid.NewGuid();
                return "Contado";
            }
            num_ticket_reserva = Guid.NewGuid();
            return "Reserva";
        }

        internal ReservaTicket(string nroReserva)
        {
            Id = Guid.NewGuid();
            NroReserva = nroReserva;
            Tipo_Pago = tipoPago(1);
            MontoTotal = new PrecioValue(0m);
            _detalle = new List<Reserva_Detalle>();
        }

        public void AgregarItem(Guid vueloId_, int cantidad, decimal precio, string instrucciones)
        {
            var detalleReserva = _detalle.FirstOrDefault(x => x.VueloId == vueloId_);
            if (detalleReserva is null)
            {
                detalleReserva = new Reserva_Detalle(vueloId_, instrucciones, precio, cantidad);
                _detalle.Add(detalleReserva);
            }
            else
            {
                detalleReserva.ModificarReserva( precio, cantidad);
            }

            MontoTotal = MontoTotal + detalleReserva.SubTotal;
            //Guid vueloId_, Guid numVuelo_, string tAsiento_, CantidadValue cantidad, PrecioValue precio) : base(DateTime.Now)
            AddDomainEvent(new ItemReservaAgregada(vueloId_, numVuelo_, tAsiento_, cantidad, precio ));
        }

        public void ConsolidarReserva()
        {
            var evento = new ReservaCreada(Id, NroReserva);
            AddDomainEvent(evento);
        }

    }
}
