using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Evento;
using Reservas.Infraestructure.EF.Config.ReadConfig;
using Reservas.Infraestructure.EF.ReadModel;
using ShareKernel.Core;

namespace Reservas.Infraestructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<ReservaReadModel> Reserva { set; get; }
        public virtual DbSet<VueloReadModel> Vuelo { set; get; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new ReservaReadConfig();
            modelBuilder.ApplyConfiguration<ReservaReadModel>(pedidoConfig);
            modelBuilder.ApplyConfiguration<DetalleReservaReadModel>(pedidoConfig);

            var productoConfig = new VueloReadConfig();
            modelBuilder.ApplyConfiguration<VueloReadModel>(productoConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaCreada>();
            modelBuilder.Ignore<ItemReservaAgregada>();
        }
    }
}
