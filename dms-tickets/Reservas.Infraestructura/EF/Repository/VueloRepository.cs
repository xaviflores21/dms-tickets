using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Reserva;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class VueloRepository : IVueloRepository
    {
        public readonly DbSet<Vuelo> _vuelos;

        public VueloRepository(WriteDbContext context)
        {
            _vuelos = context.Vuelo;
        }
        public async Task CreateAsync(Vuelo obj)
        {
            await _vuelos.AddAsync(obj);
        }

        public async Task<Vuelo> FindByIdAsync(Guid id)
        {
            return await _vuelos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Vuelo obj)
        {
            _vuelos.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Vuelo obj)
        {
            _vuelos.Update(obj);
            return Task.CompletedTask;
        }
    }
}
