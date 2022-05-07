﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Reserva;
using Reservas.Domain.Model.ValueObjects;
using Reservas.Domain.ValueObjects;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    public class ReservaWriteConfig : IEntityTypeConfiguration<ReservaTicket>,
        IEntityTypeConfiguration<Reserva_Detalle>
    {
        public void Configure(EntityTypeBuilder<ReservaTicket> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(x => x.Id);

            var nroPedidoConverter = new ValueConverter<Nro_Vuelo, string>(
                nroPedidoValue => nroPedidoValue.Value,
                nroPedido => new Nro_Vuelo(nroPedido)
            );

            builder.Property(x => x.NroPedido)
                .HasConversion(nroPedidoConverter)
                .HasColumnName("nroPedido")
                .HasMaxLength(6);

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.Total)
                .HasConversion(precioConverter)
                .HasColumnName("total")
                .HasPrecision(12, 2);

            builder.HasMany(typeof(Reserva_Detalle), "_detalle");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Detalle);
            builder.Ignore(x => x.ClienteId);
        }

        public void Configure(EntityTypeBuilder<Reserva_Detalle> builder)
        {
            builder.ToTable("DetallePedido");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Instrucciones)
               .HasColumnName("instrucciones")
               .HasMaxLength(500);

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.Precio)
                .HasConversion(precioConverter)
                .HasColumnName("precio")
                .HasPrecision(12, 2);

            builder.Property(x => x.SubTotal)
                .HasConversion(precioConverter)
                .HasColumnName("subTotal")
                .HasPrecision(12, 2);

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
                cantidadValue => cantidadValue.Value,
                cantidad => new CantidadValue(cantidad)
            );

            builder.Property(x => x.Cantidad)
                .HasConversion(cantidadConverter)
                .HasColumnName("cantidad");


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
