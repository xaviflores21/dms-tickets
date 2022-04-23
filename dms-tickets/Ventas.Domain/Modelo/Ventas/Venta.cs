using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.Evento;
using Ventas.Domain.ValueObjects;

namespace Ventas.Domain.Modelo.Ventas
{
    public class Venta : AggregateRoot<Guid>
    {
        public Guid PasajeroId { get; private set; }
        public DateTime fechaReserva { get; private set; }
        public DateTime fechaPago { get; private set; }
        public NumeroVenta numeroTicket { get; private set; }
        public PrecioValue montoTotal { get; private set; }
        public bool tipo { get; private set; }
        public string pasajero { get; private set; }

        private readonly ICollection<Tipo_Pago> _tipoPago;

        public IReadOnlyCollection<Tipo_Pago> Tipo
        {
            get 
            {
                return new ReadOnlyCollection<Tipo_Pago>(_tipoPago.ToList());
            }
        }

        internal Venta(string _numeroTicket)
        {
            Id = Guid.NewGuid();
            numeroTicket = _numeroTicket;
            montoTotal = new PrecioValue(0m);
            _tipoPago = new List<Tipo_Pago>();
        }

        public void AgregarItem(Guid _VueloId, decimal _montoReserva, decimal _montoSubTotal, int _cantidadTicket, decimal _precio, string _descripcion)
        {
            var tipoPago = _tipoPago.FirstOrDefault(x => x.VueloId == _VueloId);
            if (tipoPago is null)
            {
                tipoPago = new Tipo_Pago(_VueloId, _montoReserva, _montoSubTotal, _cantidadTicket, _precio, _descripcion);
                _tipoPago.Add(tipoPago);
            }
            else
            {
                tipoPago.ModificarVenta(_cantidadTicket, _precio);
            }

            montoTotal = montoTotal + tipoPago.montoSubTotal;

            AddDomainEvent(new ItemAgregado(_VueloId, _precio, _cantidadTicket));
        }

        public void ConsolidarPedido()
        {
            var evento = new VentaCreada(Id, numeroTicket);
            AddDomainEvent(evento);
        }

    }
}
