using System;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class VueloReadModel 
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
    }
}
