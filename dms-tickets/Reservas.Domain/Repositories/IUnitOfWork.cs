using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
