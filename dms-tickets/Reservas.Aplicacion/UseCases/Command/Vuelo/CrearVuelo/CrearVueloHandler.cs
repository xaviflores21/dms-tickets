using MediatR;
using Reservas.Application.Services;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Reservas;
using System;
using System.Threading;
using System.Threading.Tasks;
using Reservas.Domain.Repositories;
using Reservas.Domain.ValueObjects;

namespace Reservas.Application.UseCases.Command.Pedidos.CrearVuelo
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
                int _Cantidad_ = 0;
                decimal _Precio_ = 0;
                Guid _Pasaje_ = Guid.NewGuid();
                Vuelo objVuelo = _vueloFactory.Create(nroVuelo, _Tipo_Asiento_, _Cantidad_, _Precio_, _Pasaje_);

                //  foreach (var item in request.Detalle)
                // {
                objVuelo.AgregarItem(nroVuelo, _Tipo_Asiento_, _Cantidad_, _Precio_, _Pasaje_);
                //  }

                objVuelo.ConsolidarVuelo();

                await _vueloRepository.CreateAsync(objVuelo);


                await _unitOfWork.Commit();

                return objVuelo.Id;
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }
}