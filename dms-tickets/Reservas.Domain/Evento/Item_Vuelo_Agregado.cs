using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Model.ValueObjects;
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
        public Guid _Pasaje { get; }
        public Nro_Vuelo NroVuelo { get; }
        public string Tipo_Asiento { get; }
        public CantidadValue Cantidad { get; }
        public PrecioValue Precio { get; }
        

        public Item_Vuelo_Agregado(Nro_Vuelo _Numero_, string _Tipo_Asiento_, int _Cantidad_, decimal _Precio_, Guid _Pasaje_) : base(DateTime.Now)
        {
            NroVuelo = _Numero_;
            Tipo_Asiento = _Tipo_Asiento_;
            Cantidad = _Cantidad_;
            Precio = _Precio_;
            _Pasaje = _Pasaje_;
        }
    }
}
