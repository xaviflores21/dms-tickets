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
        public readonly DbSet<ReservaTicket> _reservas;

        public ReservaRepository(WriteDbContext context)
        {
            _reservas = context.Reserva;
        }

        public async Task CreateAsync(ReservaTicket obj)
        {
            await _reservas.AddAsync(obj);
        }

        public async Task<ReservaTicket> FindByIdAsync(Guid id)
        {
            return await _reservas.Include("_detalle")
                    .SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(ReservaTicket obj)
        {
            _reservas.Update(obj);

            return Task.CompletedTask;
        }
    }
}
