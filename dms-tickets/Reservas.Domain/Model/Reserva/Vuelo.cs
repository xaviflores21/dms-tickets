using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareKernel.Core;
using Reservas.Domain.Evento;
using Reservas.Domain.Model.ValueObjects;
using System.Collections.ObjectModel;

namespace Reservas.Domain.Model.Reserva
{
    public class Vuelo : AggregateRoot<Guid>
    {
        public string NumVuelo { get; private set; }
        public string TipoAsiento { get; private set; }
        public CantidadValue CantAsientos { get; private set; }
        public PrecioValue PrecioVuelo { get; private set; }

        private Vuelo()
        {
            CantAsientos = 0;
            PrecioVuelo = 0;
        }

        public Vuelo(string nvuelo_, string tasiento_, PrecioValue pVuelo_, CantidadValue cAsientos_)
        {
            Id = Guid.NewGuid();
            NumVuelo = nvuelo_;
            TipoAsiento = tasiento_;
            CantAsientos = cAsientos_;
            PrecioVuelo = pVuelo_;
        }

        public void ReducirStock(CantidadValue cantidad)
        {
            int stockResultante = CantAsientos - cantidad;
            if (stockResultante < 0)
            {
                throw new BussinessRuleValidationException("No hay asientos disponibles...");
            }
            CantAsientos = stockResultante;
        }
    }
}
