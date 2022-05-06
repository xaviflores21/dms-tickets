using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Infraestructure.EF.ReadModel;
using Reservas.Infraestructure.EF.ReadModel;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel> 
        
    {
        public void Configure(EntityTypeBuilder<VueloReadModel> builder)
        {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.NroVuelo);

            builder.Property(x => x.NroVuelo)
                .HasColumnName("NroVuelo")
                .HasMaxLength(6);

            builder.Property(x => x.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x._Pasaje)
                .WithOne(x => x.vuelo);

        }

    //    public void Configure(EntityTypeBuilder<DetallePedidoReadModel> builder)
    //    {
    //        builder.ToTable("DetallePedido");
    //        builder.HasKey(x => x.Id);

    //        builder.Property(x => x.Instrucciones)
    //            .HasColumnName("instrucciones")
    //            .HasMaxLength(500);

    //        builder.Property(x => x.Precio)
    //            .HasColumnName("precio")
    //            .HasColumnType("decimal")
    //            .HasPrecision(12, 2);

    //        builder.Property(x => x.SubTotal)
    //            .HasColumnName("subTotal")
    //            .HasColumnType("decimal")
    //            .HasPrecision(12, 2);

    //        builder.Property(x => x.Cantidad)
    //            .HasColumnName("cantidad");
    //    }
    //}
}
