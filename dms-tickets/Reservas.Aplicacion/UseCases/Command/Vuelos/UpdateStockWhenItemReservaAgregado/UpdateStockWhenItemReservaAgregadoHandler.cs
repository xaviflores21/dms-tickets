using MediatR;
using Reservas.Domain.Evento;
using Reservas.Domain.Model.Reserva;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Vuelos.UpdateStockWhenItemReservaAgregadoHandler
{
    public class UpdateStockWhenItemReservaAgregadoHandler : INotificationHandler<ItemReservaAgregada>
    {
        private readonly IVueloRepository _productoRepository;

        public UpdateStockWhenItemReservaAgregadoHandler(IVueloRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task Handle(ItemReservaAgregada notification, CancellationToken cancellationToken)
        {
            Vuelo objProducto = await _productoRepository.FindByIdAsync(notification.ProductoId);
            objProducto.ReducirStock(notification.Cantidad);
            await _productoRepository.UpdateAsync(objProducto);
        }
    }
}
