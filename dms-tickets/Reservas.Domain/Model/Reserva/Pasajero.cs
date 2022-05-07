using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reserva
{
    public class Pasajero : AggregateRoot<Guid>
    {
        public PersonCIValue CI { get; set; }
        public PersonNameValue NombreCompleto { get; set; }
        public PersonNacionalidadValue Nacionalidad { get; set; }
        public PersonTelfValue Telf { get; set; }


        public Pasajero(string ci, string nombre, string nac, string tel)
        {
            Id = Guid.NewGuid();
            CI = ci;
            NombreCompleto = nombre;
            Nacionalidad = nac;
            Telf = tel;
        }
    }
}
