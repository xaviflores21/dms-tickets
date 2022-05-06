using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Application.Dto.Pedido
{
    public class VueloDto
    {
       
        public int  NroVuelo { get;   set; }
        public string Tipo_Asiento { get;   set; }
        public decimal Cantidad { get;   set; }
        public decimal Precio { get;   set; }
        public decimal _Pasaje { get;   set; }

       // public ICollection<DetallePedidoDto> Detalle { get; set; }

        public VueloDto()
        {
            
                NroVuelo = 0;
                Tipo_Asiento = String.Empty ;
                Cantidad = 0;
                Precio = 0;
                _Pasaje = 0;
           
        }

    }
}
