using System;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class DetalleReservaReadModel
    {
        public Guid Id { get; set; }
        public string Instrucciones { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }

        public ReservaReadModel Reserva { get; set; }

        public VueloReadModel Vuelo { get; set; }

    }
}
