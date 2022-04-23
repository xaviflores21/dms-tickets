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
        public PersonNameValue ci { get; set; }
        public PersonNameValue nacionalidad { get; set; }
        public PersonNameValue telefono { get; set; }

        public Pasajero(string _nombreCompleto, string _ci, string _nacionalidad, string _telefono)
        {
            Id = Guid.NewGuid();
            nombreCompleto = _nombreCompleto;
            ci = _ci;
            nacionalidad = _nacionalidad;
            telefono = _telefono;
        }
    }
}
