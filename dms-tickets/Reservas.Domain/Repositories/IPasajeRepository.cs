using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IPasajeRepository : IRepository<Vuelo, Guid>
    {
        Task UpdateAsync(Vuelo obj);

        Task RemoveAsync(Vuelo obj);

    }
}
