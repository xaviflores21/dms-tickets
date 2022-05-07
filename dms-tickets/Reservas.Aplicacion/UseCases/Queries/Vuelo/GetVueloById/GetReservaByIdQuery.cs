using MediatR;
using Reservas.Application.Dto.Reserva;
using System;

namespace Reservas.Application.UseCases.Queries.Vuelo.GetVueloById
{
    public class GetReservaByIdQuery : IRequest<ReservaDto>
    {
        public Guid Id { get; set; }
        public GetReservaByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetReservaByIdQuery() { }
    }
}
