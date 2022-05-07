 
using Reservas.Domain.Model.Reserva;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IReservaRepository : IRepository<ReservaTicket, Guid>
    {
        Task UpdateAsync(ReservaTicket obj);
    }
}
