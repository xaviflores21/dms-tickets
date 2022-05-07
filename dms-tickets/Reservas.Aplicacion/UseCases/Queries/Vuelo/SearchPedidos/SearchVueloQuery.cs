using MediatR;
using Reservas.Application.Dto.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Queries.Vuelo.GetPedidosCancelados
{
    public class SearchVueloQuery : IRequest<ICollection<VueloDto>>
    {
        public string NroVuelo { get; set; }
        public string Tipo_Asiento { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal _Pasaje { get; set; }
    }
}
