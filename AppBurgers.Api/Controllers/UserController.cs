
namespace AppBurgers.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AppBurgers.Core.Interfaces;
    using AppBurgers.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }
    }
}