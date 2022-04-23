using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Modelo.Pasajeros
{
    public class Pasajero : AggregateRoot<Guid>
    {
        public PersonNameValue nombreCompleto { get; set; }

        public Pasajero(string nombre)
        {
            Id = Guid.NewGuid();
            nombreCompleto = nombre;
        }
    }
}
