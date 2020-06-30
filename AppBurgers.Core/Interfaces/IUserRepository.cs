
namespace AppBurgers.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Entities;

    public interface IUserRepository
    {
        IEnumerable<Usuario> GetUsers();
    }
}