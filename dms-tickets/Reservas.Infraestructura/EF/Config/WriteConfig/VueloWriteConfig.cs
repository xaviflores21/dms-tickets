using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Reserva;
using Reservas.Domain.Model.ValueObjects;
using Reservas.Domain.ValueObjects;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    public class VueloWriteConfig : IEntityTypeConfiguration<Vuelo>
    {
        public void Configure(EntityTypeBuilder<Vuelo> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.PrecioVenta)
                .HasConversion(precioConverter)
                .HasColumnName("precioVenta")
                .HasPrecision(12, 2);

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
               cantidadValue => cantidadValue.Value,
               cantidad => new CantidadValue(cantidad)
           );

            builder.Property(x => x.StockActual)
                .HasConversion(cantidadConverter)
                .HasColumnName("stockActual");
        }
    }
}
