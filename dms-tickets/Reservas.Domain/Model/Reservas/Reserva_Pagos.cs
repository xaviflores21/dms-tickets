using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas
{
    public class Reserva_Pagos : Entity<Guid>
    {
        // public class DetallePedido : Entity<Guid>
        //  {
        //TODO: Crear value objects para las propiedades
        public decimal ReservaId { get; private set; }
        public Guid VueloId { get; private set; }
        public Guid PasajeroId { get; private set; }

        public decimal Tipo_Pagos { get; private set; }
        public decimal Deuda { get; private set; }
        public string Descripcion { get; private set; }
        public string Estado1 { get; private set; }
        public string Estado2 { get; private set; }
        //public CantidadValue Cantidad { get; private set; }
         //   public PrecioValue Precio { get; private set; }
         //   public PrecioValue SubTotal { get; private set; }

            internal Reserva_Pagos(Guid guid, string instrucciones,
                int cantidad, decimal precio)
            {
                Id = Guid.NewGuid();
                ProductoId = productoId;
                Instrucciones = instrucciones;
                Cantidad = cantidad;
                Precio = precio;
                SubTotal = new PrecioValue(precio * cantidad);
            }

            private DetallePedido() { }

            internal void ModificarPedido(int cantidad, decimal precio)
            {
                Cantidad = cantidad;
                Precio = precio;
                SubTotal = precio * cantidad;
            }
    //    }
    }
}
