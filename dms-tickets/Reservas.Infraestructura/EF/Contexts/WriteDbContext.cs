using Microsoft.EntityFrameworkCore; 
using Reservas.Domain.Evento;
using Reservas.Domain.Model.Reserva;
using Reservas.Infraestructure.EF.Config.WriteConfig;
using ShareKernel.Core;

namespace Reservas.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<ReservaTicket> Reserva { get; set; }
        public virtual DbSet<Vuelo> Vuelo { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new ReservaWriteConfig();
            modelBuilder.ApplyConfiguration<ReservaTicket>(pedidoConfig);
            modelBuilder.ApplyConfiguration<Reserva_Detalle>(pedidoConfig);

            var productoConfig = new VueloWriteConfig();
            modelBuilder.ApplyConfiguration<Vuelo>(productoConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaCreada>();
            modelBuilder.Ignore<ItemReservaAgregada>();
        }
    }
}
