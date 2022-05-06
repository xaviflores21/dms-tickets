using MediatR;
using Reservas.Application.Dto.Vuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Queries.Pedidos.GetPedidosCancelados
{
    public class SearchVueloQuery : IRequest<ICollection<VueloDto>>
    {
        public string NroPedido { get; set; }
    }
}
