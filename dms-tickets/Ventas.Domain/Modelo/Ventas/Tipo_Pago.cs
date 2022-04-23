using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.ValueObjects;

namespace Ventas.Domain.Modelo.Ventas
{
    public class Tipo_Pago : Entity<Guid>
    {
        //TODO: Crear value objects para las propiedades
        public Guid VueloId { get; private set; }
        public PrecioValue montoReserva { get; private set; }
        public PrecioValue montoSubTotal { get; private set; }
        public PrecioValue cantidadTicket { get; private set; }
        public PrecioValue precio { get; private set; }
        public string descripcion { get; private set; }

        internal Tipo_Pago(Guid _vueloId,  decimal _montoReserva, decimal _montoSubTotal, 
            int _cantidadTicket, decimal _precio, string _descripcion)
        {
            Id = Guid.NewGuid();
            VueloId = _vueloId;
            montoReserva = _montoReserva;
            cantidadTicket = _cantidadTicket;
            precio = _precio;
            descripcion = _descripcion;
            montoSubTotal = new PrecioValue(_precio * _cantidadTicket);
        }

        internal void ModificarVenta(int _cantidadTicket, decimal _precio)
        {
            cantidadTicket = _cantidadTicket;
            precio = _precio;
            montoSubTotal = _precio * _cantidadTicket;
        }
    }
}
