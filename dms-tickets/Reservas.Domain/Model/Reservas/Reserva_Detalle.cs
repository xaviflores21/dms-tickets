using Reservas.Domain.Model.ValueObjects;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas
{
    public class Reserva_Detalle : Entity<Guid>
    {
        //TODO: Crear value objects para las propiedades
        public Guid ProductoId { get; private set; }
        public string Instrucciones { get; private set; }
        public CantidadValue Cantidad { get; private set; }
        public PrecioValue Precio { get; private set; }
        public PrecioValue SubTotal { get; private set; }

        internal Reserva_Detalle(Guid productoId, string instrucciones,
            int cantidad, decimal precio)
        {
            Id = Guid.NewGuid();
            ProductoId = productoId;
            Instrucciones = instrucciones;
            Cantidad = cantidad;
            Precio = precio;
            SubTotal = new PrecioValue(precio * cantidad);
        }

        private Reserva_Detalle() { }

        internal void ModificarPedido(int cantidad, decimal precio)
        {
            Cantidad = cantidad;
            Precio = precio;
            SubTotal = precio * cantidad;
        }
    }
}
