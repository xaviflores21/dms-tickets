using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Evento
{
    public record VueloCreado : DomainEvent
    {
        
        public Nro_Vuelo NroVuelo { get;  }
        public string Tipo_Asiento { get;   }
        public PrecioValue Cantidad { get;   }
        public PrecioValue Precio { get;   }
        public Guid _Pasaje { get;  }

        public VueloCreado(Nro_Vuelo _Numero_, string _Tipo_Asiento_, int _Cantidad_, decimal _Precio_, Guid _Pasaje_) : base(DateTime.Now)
        {
            NroVuelo = _Numero_;
            Tipo_Asiento = _Tipo_Asiento_;
            Cantidad = _Cantidad_;
            Precio = _Precio_;
            _Pasaje = _Pasaje_;

        }
    }
}
