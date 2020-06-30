
namespace AppBurgers.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using AppBurgers.Core.Entities;
    using AppBurgers.Core.Interfaces;
    using AppBurgers.Infrastructure.Data;
    using AppBurgers.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppBurgerContext _context;
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new AppBurgerContext());


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _unitOfWork.Usuarios.Get();
            if (users != null)
            {
                return Ok(users);

            }
            else
            {
                return Ok();
            }
        }

        [HttpGet('Id')]
        public IActionResult GetById(int id)
        {
            var users = _unitOfWork.Usuarios.GetById(id);
            if (users != null)
            {
                return Ok(users);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Usuarios.Update(user);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DataException ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("id")]
        public IActionResult HttpDeleteUser(int id)
        {
            if (id != 0)
            {
                _unitOfWork.Usuarios.Delete(id);
                _unitOfWork.Save();
                return Ok("Usuario elimnado..");
            }
            else
            {
                return BadRequest("Usuario con id incorrecto");
            }
        }
    }
}