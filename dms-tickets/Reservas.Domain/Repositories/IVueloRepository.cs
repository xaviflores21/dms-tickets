using Reservas.Domain.Model.Reserva;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IVueloRepository : IRepository<Vuelo, Guid>
    {
        Task UpdateAsync(Vuelo obj);

        Task RemoveAsync(Vuelo obj);

    }
}
