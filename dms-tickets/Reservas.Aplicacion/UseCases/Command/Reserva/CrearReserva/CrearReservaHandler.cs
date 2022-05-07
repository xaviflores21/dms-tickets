using MediatR;
using Reservas.Application.Services;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Reservas;
using System;
using System.Threading;
using System.Threading.Tasks;
using Reservas.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Reservas.Application.UseCases.Command.Reserva.CrearReserva
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Guid>
    {
        private readonly IReservaRepository _pedidoRepository;
        private readonly ILogger<CrearReservaHandler> _logger;
        private readonly IReservaService _pedidoService;
        private readonly IReservaFactory _pedidoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearReservaHandler(IReservaRepository pedidoRepository,
            ILogger<CrearReservaHandler> logger,
            IReservaService pedidoService,
            IReservaFactory pedidoFactory,
            IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
            _pedidoService = pedidoService;
            _pedidoFactory = pedidoFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string nroPedido = await _pedidoService.GenerarNroPedidoAsync();
                Reserva objPedido = _pedidoFactory.Create(nroPedido);

                foreach (var item in request.Detalle)
                {
                    objPedido.AgregarItem(item.ProductoId, item.Cantidad, item.Precio, item.Instrucciones);
                }

                objPedido.ConsolidarPedido();

                await _pedidoRepository.CreateAsync(objPedido);


                await _unitOfWork.Commit();

                return objPedido.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }
}