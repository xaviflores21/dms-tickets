using MediatR;
using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Command.Reserva.CrearReserva
{ 
    public class CrearReservaCommand : IRequest<Guid>
    {
        private CrearReservaCommand() { }
        public CrearReservaCommand(List<DetalleReservaDto> detalle)
        {
            Detalle = detalle;
        }

        public List<DetalleReservaDto> Detalle { get; set; }

    }
}
