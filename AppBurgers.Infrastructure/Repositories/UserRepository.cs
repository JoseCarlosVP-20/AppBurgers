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

        // public IEnumerable<Usuario> GetUsers(){
        //     var users= Enumerable.Range(1,10).Select(x => new Usuario{
        //         UserId = x,
        //         FirstName =$"Juan {x}",
        //         LastName="Perez",
        //         Mail = $"Jperez{x}@gmail.com",
        //         Telephone =$"841{x}97{x}{x}"
        //     });
        //     return users;
        // }


    }
}