using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas
{
    public class Reserva_Pago : Entity<Guid>
    {
        // public class DetallePedido : Entity<Guid>

        //TODO: Crear value objects para las propiedades
        
        public bool Tipo_Pagos { get; private set; }
        public PrecioValue MontoTotal { get; private set; }
        public decimal Deuda { get; private set; }
        public string Descripcion { get; private set; }
        public string Estado1 { get; private set; }
        public string Estado2 { get; private set; }
        public Guid VueloId { get; private set; }
        public Guid PasajeroId { get; private set; }

        internal Reserva_Pago(bool tipopago_, decimal deuda_, string desc, string est1_, string est2_, 
            Guid idVuelo, Guid idPasajero)
        {
            Id = Guid.NewGuid();
            Tipo_Pagos = tipopago_;
            Deuda = deuda_;
            Descripcion = desc;
            Estado1 = est1_;
            Estado2 = est2_;
            VueloId = idVuelo;
            PasajeroId = idPasajero;
            MontoTotal = new PrecioValue(Vuelo.Precio * Vuelo.Cantidad);

            //ProductoId = productoId;
            //Instrucciones = instrucciones;
            //Cantidad = cantidad;
            //Precio = precio;
            //SubTotal = new PrecioValue(precio * cantidad);
        }


        private Reserva_Pago() { }

        internal void ModificarVuelo(int cantidad, decimal precio)
        {
            MontoTotal = precio * cantidad;
        }
    }
}
