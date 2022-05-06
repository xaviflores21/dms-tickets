using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Application.Dto.Vuelo;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Queries.Pedidos.GetPedidoById
{
    public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdQuery, VueloDto>
    {
        private readonly IVueloRepository _pedidoRepository;
        private readonly ILogger<GetPedidoByIdQuery> _logger;

        public GetPedidoByIdHandler(IVueloRepository pedidoRepository, ILogger<GetPedidoByIdQuery> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public async Task<VueloDto> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            VueloDto result = null;
            try
            {
                Vuelos objPedido = await _pedidoRepository.FindByIdAsync(request.Id);

                result = new VueloDto()
                {
                    Id = objPedido.Id,
                    NroPedido = objPedido.NroPedido,
                    Total = objPedido.Total
                };

                foreach (var item in objPedido.Detalle)
                {
                    result.Detalle.Add(new DetallePedidoDto()
                    {
                        Cantidad = item.Cantidad,
                        Instrucciones = item.Instrucciones,
                        Precio = item.Precio,
                        ProductoId = item.ProductoId
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
