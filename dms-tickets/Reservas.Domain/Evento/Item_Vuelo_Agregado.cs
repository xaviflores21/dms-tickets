using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Evento
{
   
    public record Item_Vuelo_Agregado : DomainEvent
    {
 
        public Nro_Vuelo NroVuelo { get; private set; }
        public string Tipo_Asiento { get; private set; }
        public PrecioValue Cantidad { get; private set; }
        public PrecioValue Precio { get; private set; }
        public Pasaje _Pasaje { get; private set; }
      
        public Item_Vuelo_Agregado(Nro_Vuelo _Numero_, string _Tipo_Asiento_, PrecioValue _Cantidad_, PrecioValue _Precio_, Pasaje _Pasaje_) : base(DateTime.Now)
        {
            NroVuelo = _Numero_;
            Tipo_Asiento = _Tipo_Asiento_;
            Cantidad = _Cantidad_;
            Precio = _Precio_;
            _Pasaje = _Pasaje_;
        }
    }
}
