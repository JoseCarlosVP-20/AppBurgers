using System.Collections.Generic;
using System.Linq;
using AppBurgers.Core.Entities;
using AppBurgers.Core.Interfaces;
using AppBurgers.Infrastructure.Data;

namespace AppBurgers.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppBurgerContext _context;
        public UserRepository(AppBurgerContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetUsers()
        {
            var users = _context.Usuario.ToList();
            return users;
        }
    }
}