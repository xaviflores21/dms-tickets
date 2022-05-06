 
using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IVueloRepository : IRepository<Vuelos, Guid>
    {
        Task UpdateAsync(Vuelos obj);
    }
}
