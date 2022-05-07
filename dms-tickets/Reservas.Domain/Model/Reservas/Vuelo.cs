using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareKernel.Core;
using Reservas.Domain.Evento;
using Reservas.Domain.Model.ValueObjects;
using System.Collections.ObjectModel;

namespace Reservas.Domain.Model.Reservas
{
    public class Vuelo : AggregateRoot<Guid>
    {
        // public class Pedido : AggregateRoot<Guid>

        // public Guid ClienteId { get; private set; }
        // public int NroVuelo { get; private set; }
        public Nro_Vuelo NroVuelo { get; private set; }
        public string Tipo_Asiento { get; private set; }
        public static CantidadValue Cantidad { get; private set; }
        public static PrecioValue Precio { get; private set; }
        public Guid idPasaje { get; private set; }



        public Vuelo()
        {
            Precio = 0;
            Cantidad = 0;
        }

        internal Vuelo(Nro_Vuelo _Numero_, string _Tipo_Asiento_, CantidadValue _Cantidad_, PrecioValue _Precio_, Guid _Pasaje_)
        {
            NroVuelo = _Numero_;
            Tipo_Asiento = _Tipo_Asiento_;
            Cantidad = _Cantidad_;
            Precio = _Precio_;
            idPasaje = _Pasaje_;
        }


        private readonly ICollection<Reserva_Pago> _reservaPago;

        public IReadOnlyCollection<Reserva_Pago> ReservaPago
        {
            get
            {
                return new ReadOnlyCollection<Reserva_Pago>(_reservaPago.ToList());
            }
        }

        public void ReducirAsientos(CantidadValue cantidad_)
        {
            int cantidadAsientosResultantes = Cantidad - cantidad_;
            if (cantidadAsientosResultantes < 0)
            {
                throw new BussinessRuleValidationException("La cantidad de asientos es insuficiente");
            }
            Cantidad = cantidadAsientosResultantes;
        }


        internal void ModificarVuelo(int cantidad_, decimal precio_)
        {
            Cantidad = cantidad_;
            Precio = precio_;
        }

        private readonly ICollection<Vuelo> _vuelos;

        public void AgregarItem(Nro_Vuelo _Numero_, string _Tipo_Asiento_, int _Cantidad_, decimal _Precio_, Guid _Pasaje_)
        {
            var reservaPagos = _vuelos.FirstOrDefault(x => NroVuelo == _Numero_);
            if (reservaPagos is null)
            {
                reservaPagos = new Vuelo(_Numero_, _Tipo_Asiento_, _Cantidad_, _Precio_, _Pasaje_);
                _vuelos.Add(reservaPagos);
            }
            else
            {
                reservaPagos.ModificarVuelo(_Cantidad_, _Precio_);
            }
            AddDomainEvent(new Item_Vuelo_Agregado(_Numero_, _Tipo_Asiento_, _Cantidad_, _Precio_, _Pasaje_));
        }

        public void ConsolidarVuelo()
        {
            var evento = new VueloCreado(NroVuelo, Tipo_Asiento, Cantidad, Precio, idPasaje);
            AddDomainEvent(evento);
        }
    }
}
