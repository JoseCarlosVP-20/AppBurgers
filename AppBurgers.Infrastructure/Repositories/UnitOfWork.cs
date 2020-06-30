using AppBurgers.Core.Entities;
using AppBurgers.Core.Interfaces;
using AppBurgers.Infrastructure.Data;

namespace AppBurgers.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppBurgerContext _context;
        private readonly BaseRepository<Usuario> _usuario;
        private readonly BaseRepository<Producto> _producto;

        public UnitOfWork(AppBurgerContext context)
        {
            _context = context;
        }
        public IRepository<Usuario> Usuarios => _usuario ?? new BaseRepository<Usuario> (_context);

        public IRepository<Producto> Producto => _producto ?? new BaseRepository<Producto>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}