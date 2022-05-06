using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Services
{
    public class VueloService : IVueloService
    {
        public Task<string> GenerarNroVueloAsync() => Task.FromResult("ABC");
    }
}
