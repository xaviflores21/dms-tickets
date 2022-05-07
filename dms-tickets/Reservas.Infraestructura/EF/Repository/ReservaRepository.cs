using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Reserva;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        public readonly DbSet<ReservaTicket> _pedidos;

        public ReservaRepository(WriteDbContext context)
        {
            _pedidos = context.Reserva;
        }

        public async Task CreateAsync(ReservaTicket obj)
        {
            await _pedidos.AddAsync(obj);
        }

        public async Task<ReservaTicket> FindByIdAsync(Guid id)
        {
            return await _pedidos.Include("_detalle")
                    .SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(ReservaTicket obj)
        {
            _pedidos.Update(obj);

            return Task.CompletedTask;
        }
    }
}
