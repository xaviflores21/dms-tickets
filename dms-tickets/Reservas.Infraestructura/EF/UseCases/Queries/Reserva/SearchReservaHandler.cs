using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Queries.Reserva.SearchReserva;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.ReadModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.UseCases.Queries.Reserva
{
    public class SearchReservaHandler :
        IRequestHandler<SearchReservaQuery, ICollection<ReservaDto>>
    {
        private readonly DbSet<ReservaReadModel> _pedidos;

        public SearchReservaHandler(ReadDbContext context)
        {
            _pedidos = context.Reserva;
        }

        public async Task<ICollection<ReservaDto>> Handle(SearchReservaQuery request, CancellationToken cancellationToken)
        {

            var pedidoList = await _pedidos
                            .AsNoTracking()
                            .Include(x => x.Detalle)
                            .ThenInclude(x => x.Vuelo)
                            .Where(x => x.NroPedido.Contains(request.NroPedido))
                            .ToListAsync();

            var result = new List<ReservaDto>();

            foreach (var objPedido in pedidoList)
            {
                var pedidoDto = new ReservaDto()
                {
                    Id = objPedido.Id,
                    NroPedido = objPedido.NroPedido,
                    Total = objPedido.Total
                };

                foreach (var item in objPedido.Detalle)
                {
                    pedidoDto.Detalle.Add(new DetalleReservaDto()
                    {
                        Cantidad = item.Cantidad,
                        Instrucciones = item.Instrucciones,
                        Precio = item.Precio,
                        ProductoId = item.Vuelo.Id
                    });
                }
                result.Add(pedidoDto);
            }

            return result;
        }
    }
}
