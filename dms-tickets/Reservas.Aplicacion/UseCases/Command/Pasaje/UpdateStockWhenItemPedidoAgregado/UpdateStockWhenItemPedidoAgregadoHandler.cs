using MediatR;
using Reservas.Domain.Evento;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Pasaje.UpdateStockWhenItemPedidoAgregado
{
    public class UpdateStockWhenItemPedidoAgregadoHandler : INotificationHandler<Item_Vuelo_Agregado>
    {
        private readonly IPasajeRepository _productoRepository;

        public UpdateStockWhenItemPedidoAgregadoHandler(IPasajeRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task Handle(Item_Vuelo_Agregado notification, CancellationToken cancellationToken)
        {
            Vuelo objProducto = await _productoRepository.FindByIdAsync(notification._Pasaje);
            objProducto.ReducirAsientos(notification.Cantidad);

            await _productoRepository.UpdateAsync(objProducto);


        }
    }
}
