using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    public class ReservaReadConfig : IEntityTypeConfiguration<ReservaReadModel>,
        IEntityTypeConfiguration<DetalleReservaReadModel>
    {
        public void Configure(EntityTypeBuilder<ReservaReadModel> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroPedido)
                .HasColumnName("nroReserva")
                .HasMaxLength(6);

            builder.Property(x => x.Total)
                .HasColumnName("monto_total")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x.Detalle)
                .WithOne(x => x.Reserva);

        }

        public void Configure(EntityTypeBuilder<DetalleReservaReadModel> builder)
        {
            builder.ToTable("Reserva_Detalle");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Instrucciones)
                .HasColumnName("glosa")
                .HasMaxLength(500);

            builder.Property(x => x.Precio)
                .HasColumnName("precio")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.SubTotal)
                .HasColumnName("subTotal")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.Cantidad)
                .HasColumnName("cantidad");
        }
    }
}
