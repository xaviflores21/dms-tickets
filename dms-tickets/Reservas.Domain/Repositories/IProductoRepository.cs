using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IProductoRepository : IRepository<Vuelos, Guid>
    {
        Task UpdateAsync(Vuelos obj);

        Task RemoveAsync(Vuelos obj);

    }
}
