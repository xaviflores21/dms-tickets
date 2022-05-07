using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Event;
 
using Pedidos.Infraestructure.EF.Config.WriteConfig;
using Reservas.Domain.Evento;
using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System.Data.Entity;

namespace Reservas.Infraestructure.EF.Contexts
{
    public class WriteDbContext : System.Data.Entity.DbContext
    {
        public virtual System.Data.Entity.DbSet<Vuelo> Vuelos { get; set; }
       // public virtual DbSet<Producto> Producto { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var VueloConfig = new VueloWriteConfig();
            modelBuilder.ApplyConfiguration<Vuelo>(VueloConfig);
           // modelBuilder.ApplyConfiguration<DetallePedido>(pedidoConfig);

            //var productoConfig = new ProductoWriteConfig();
            //modelBuilder.ApplyConfiguration<Producto>(productoConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaCreada>();
            modelBuilder.Ignore<ItemReservaAgregada>();
        }
    }
}
