using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Domain.Repositories;
using Reservas.Application.Dto.Reserva;
using System;
using System.Threading;
using System.Threading.Tasks;
using Reservas.Domain.Model.Reserva;

namespace Reservas.Application.UseCases.Queries.Reserva.GetReservaById
{
    public class GetReservaByIdHandler : IRequestHandler<GetReservaByIdQuery, ReservaDto>
    {
        private readonly IReservaRepository _pedidoRepository;
        private readonly ILogger<GetReservaByIdQuery> _logger;

        public GetReservaByIdHandler(IReservaRepository pedidoRepository, ILogger<GetReservaByIdQuery> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public async Task<ReservaDto> Handle(GetReservaByIdQuery request, CancellationToken cancellationToken)
        {
            ReservaDto result = null;
            try
            {
                ReservaTicket objPedido = await _pedidoRepository.FindByIdAsync(request.Id);

                result = new ReservaDto()
                {
                    Id = objPedido.Id,
                    NroPedido = objPedido.NroReserva,
                    Total = objPedido.MontoTotal
                };

                foreach (var item in objPedido.Detalle)
                {
                    result.Detalle.Add(new DetalleReservaDto()
                    {
                        Cantidad = item.Cantidad,
                        Instrucciones = item.Glosa,
                        Precio = item.Precio,
                        ProductoId = item.VueloId
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Pedido con id: { PedidoId }", request.Id);
            }

            return result;
        }
    }
}
