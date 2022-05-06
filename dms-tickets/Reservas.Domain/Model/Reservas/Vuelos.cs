using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareKernel.Core;
using Reservas.Domain.Evento;
using Pedidos.Domain.Event;

namespace Reservas.Domain.Model.Reservas
{
    public class Vuelos : AggregateRoot<Guid>
    {
        // public class Pedido : AggregateRoot<Guid>
        //    {
        // public Guid ClienteId { get; private set; }
        // public int NroVuelo { get; private set; }
        public Nro_Vuelo NroVuelo { get; private set; }
        public string Tipo_Asiento { get; private set; }
        public PrecioValue Cantidad { get; private set; }
        public PrecioValue Precio { get; private set; }
        public Pasaje _Pasaje { get; private set; }


        //   private readonly ICollection<DetallePedido> _detalle;

        //public IReadOnlyCollection<DetallePedido> Detalle
        //{
        //    get
        //    {
        //        return new ReadOnlyCollection<DetallePedido>(_detalle.ToList());
        //    }
        //}

        //private Vuelos() { }

        internal Vuelos(Nro_Vuelo _Numero_, string _Tipo_Asiento_, PrecioValue _Cantidad_, PrecioValue _Precio_, Pasaje _Pasaje_)
        {
            NroVuelo = _Numero_;
            Tipo_Asiento = _Tipo_Asiento_;
            Cantidad = _Cantidad_;
            Precio = _Precio_;
            _Pasaje = _Pasaje_;
        }
        internal void ModificarPedido(decimal cantidad, decimal precio)
        {
            Cantidad = cantidad;
            Precio = precio;

        }
        private readonly ICollection<Vuelos> _vuelos;
        public void AgregarItem(Nro_Vuelo _Numero_, string _Tipo_Asiento_, PrecioValue _Cantidad_, PrecioValue _Precio_, Pasaje _Pasaje_)
        {
            var detallePedido = _vuelos.FirstOrDefault(x => NroVuelo == _Numero_);
            if (detallePedido is null)
            {
                detallePedido = new Vuelos(_Numero_, _Tipo_Asiento_, _Cantidad_, _Precio_, _Pasaje_);
                _vuelos.Add(detallePedido);
            }
            else
            {
                detallePedido.ModificarPedido(_Cantidad_, _Precio_);
            }
            AddDomainEvent(new Item_Vuelo_Agregado(_Numero_, _Tipo_Asiento_, _Cantidad_, _Precio_, _Pasaje_));
        }

        public void ConsolidarPedido()
        {
            var evento = new VueloCreado(NroVuelo, Tipo_Asiento,Cantidad,Precio,_Pasaje);
            AddDomainEvent(evento);
        }
        //  }
    }
}
