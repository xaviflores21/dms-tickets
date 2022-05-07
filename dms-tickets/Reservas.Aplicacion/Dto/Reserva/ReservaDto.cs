using Pedidos.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Dto.Reserva
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public string NroPedido { get; set; }
        public decimal Total { get; set; }
        public ICollection<DetalleReservaDto> Detalle { get; set; }

        public ReservaDto()
        {
            Detalle = new List<DetalleReservaDto>();
        }

    }
}
