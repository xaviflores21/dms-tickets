using Reservas.Domain.Model.ValueObjects;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reserva
{
    public class Reserva_Detalle : Entity<Guid>
    {
        //TODO: Crear value objects para las propiedades
        public Guid VueloId { get; private set; }
        public string Glosa { get; private set; }
        public PrecioValue Precio { get; private set; }
        public CantidadValue Cantidad { get; private set; }
        public PrecioValue SubTotal { get; private set; }

        internal Reserva_Detalle(Guid vueloId_, string glosa_, decimal precio_, int cantidad_)
        {
            Id = Guid.NewGuid();
            VueloId = vueloId_;
            Glosa = glosa_;
            Precio = precio_;
            Cantidad = cantidad_;
            SubTotal = new PrecioValue(precio_ * cantidad_);
        }

        private Reserva_Detalle() { }

        internal void ModificarReserva(decimal precio_, int cantidad_)
        {
            Precio = precio_;
            Cantidad = cantidad_;
            SubTotal = precio_ * cantidad_;
        }
    }
}
