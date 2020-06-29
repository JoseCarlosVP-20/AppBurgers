using System.Collections.Generic;
using System.Linq;
using AppBurgers.Core.Entities;

namespace AppBurgers.Infrastructure.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetUsers(){
            var users= Enumerable.Range(1,10).Select(x => new User{
                UserId = x,
                FirstName =$"Juan {x}",
                LastName="Perez",
                Mail = $"Jperez{x}@gmail.com",
                Telephone =$"841{x}97{x}{x}"
            });
            return users;
        }
    }
}