
namespace AppBurgers.Core.Interfaces
{
    using AppBurgers.Core.Entities;

    public interface IUnitOfWork
    {
        IRepository<Usuario> Usuarios { get; }
        IRepository<Producto> Producto { get; }
        void Save();
    }
}