using MediatR;
using Reservas.Application.Dto.Vuelo;
using System;

namespace Reservas.Application.UseCases.Queries.Vuelo.GetPedidoById
{
    public class GetPedidoByIdQuery : IRequest<VueloDto>
    {
        public Guid Id { get; set; }

        public GetPedidoByIdQuery(Guid id)
        {
            Id = id;
        }

        public GetPedidoByIdQuery() { }
    }
}
