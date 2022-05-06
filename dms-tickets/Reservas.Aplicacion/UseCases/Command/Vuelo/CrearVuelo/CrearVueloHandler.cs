using MediatR;
 
using Reservas.Application.Services;
using Reservas.Domain.Factories;
 
using System;
using System.Threading;
using System.Threading.Tasks;

using Reservas.Domain.Repositories;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;

namespace Pedidos.Application.UseCases.Command.Pedidos.CrearPedido
{
    public class CrearVueloHandler : IRequestHandler<CrearVueloCommand, Guid>
    {
        private readonly IVueloRepository _vueloRepository;
        //  private readonly ILogger<CrearVueloHandler> _logger;
        private readonly IVueloService _vueloService;
        private readonly IVueloFactory _vueloFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearVueloHandler(IVueloRepository vueloRepository,
            //   ILogger<CrearVueloHandler> logger,
            IVueloService vueloService,
            IVueloFactory vueloFactory,
            IUnitOfWork unitOfWork)
        {
            _vueloRepository = vueloRepository;
            //  _logger = logger;
            _vueloService = vueloService;
            _vueloFactory = vueloFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearVueloCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string nroVuelo = await _vueloService.GenerarNroVueloAsync();
                string _Tipo_Asiento_ = string.Empty;
                PrecioValue _Cantidad_ = 0;
                PrecioValue _Precio_ = 0;
                Pasaje _Pasaje_ = 1;
                Vuelos objPedido = _vueloFactory.Create(nroVuelo, _Tipo_Asiento_,  _Cantidad_,  _Precio_,  _Pasaje_);

              //  foreach (var item in request.Detalle)
               // {
                    objPedido.AgregarItem(nroVuelo,_Tipo_Asiento_,_Cantidad_,_Precio_,_Pasaje_);
              //  }

                objPedido.ConsolidarPedido();

                await _vueloRepository.CreateAsync(objPedido);


                await _unitOfWork.Commit();

                return objPedido.Id;
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }
}
