using MediatR;
using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Queries.Vuelo.SearchVuelos
{
    public class SearchReservaQuery : IRequest<ICollection<ReservaDto>>
    {
        public string NroPedido { get; set; }
    }
}
