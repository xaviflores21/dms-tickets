using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Command.Reserva.CrearReserva;
using Reservas.Application.UseCases.Queries.Reserva.GetReservaById;
using Reservas.Application.UseCases.Queries.Reserva.SearchReserva;
using System;
using System.Threading.Tasks;

namespace Reservas.WebApi
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearReservaCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        private IActionResult Ok(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById([FromRoute] GetReservaByIdQuery command)
        {
            ReservaDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchReservaQuery query)
        {
            var pedidos = await _mediator.Send(query);

            if (pedidos == null)
                return BadRequest();

            return Ok(pedidos);
        }
    }
}
