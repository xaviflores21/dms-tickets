using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class VueloReadModel
    {
        public Nro_Vuelo NroVuelo { get;   set; }
        public string Tipo_Asiento { get;   set; }
        public decimal Cantidad { get;   set; }
        public decimal Precio { get;   set; }
        public decimal _Pasaje { get;   set; }

        ///   public ICollection<DetallePedidoReadModel> Detalle { get; set; }


    }
}
