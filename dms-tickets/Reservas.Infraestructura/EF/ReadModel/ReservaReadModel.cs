using Reservas.Domain.Model.Reserva;
using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class ReservaReadModel
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public string NroPedido { get; set; }

        public ICollection<DetalleReservaReadModel> Detalle { get; set; }


    }
}
