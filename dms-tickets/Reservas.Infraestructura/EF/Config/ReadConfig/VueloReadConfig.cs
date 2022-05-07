
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel>
    {
        public void Configure(EntityTypeBuilder<VueloReadModel> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");


            builder.Property(x => x.PrecioVenta)
                .HasColumnName("precioVenta")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.StockActual)
                .HasColumnName("stockActual");

        }
    }
}
