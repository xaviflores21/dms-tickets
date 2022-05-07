using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Services
{
    public class ReservaService : IReservaService
    {
        public Task<string> GenerarNroReservaAsync() => Task.FromResult("132");
    }
}
