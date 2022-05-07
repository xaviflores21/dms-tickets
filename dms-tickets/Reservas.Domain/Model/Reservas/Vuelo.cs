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

namespace Reservas.Domain.Model.Reservas
{
    public class Vuelo : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }
        public PrecioValue PrecioVenta { get; private set; }
        public CantidadValue StockActual { get; private set; }

        private Vuelo()
        {
            PrecioVenta = 0;
            StockActual = 0;
        }

        public Vuelo(string nombre, PrecioValue precioVenta, CantidadValue stockActual)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            PrecioVenta = precioVenta;
            StockActual = stockActual;
        }

        public void ReducirStock(CantidadValue cantidad)
        {
            int stockResultante = StockActual - cantidad;
            if (stockResultante < 0)
            {
                throw new BussinessRuleValidationException("La cantidad de stock actual es insuficiente");
            }
            StockActual = stockResultante;
        }
    }
}
