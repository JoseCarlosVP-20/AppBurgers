
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

  [Route("api/v1/Appburger/[controller]")]
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

    [HttpGet("id")]
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

    [HttpPost]
    public IActionResult Create(Usuario user)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _unitOfWork.Usuarios.Insert(user);
          _unitOfWork.Save();
          return Created("Appburger/create", user);
        }
      }
      catch (DataException ex)
      {
        return BadRequest(ex);
      }
      return BadRequest(user);
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

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
      if (id != 0)
      {
        _unitOfWork.Usuarios.Delete(id);
        _unitOfWork.Save();
        return Ok("Usuario eliminado..");
      }
      else
      {
        return BadRequest("Usuario con id incorrecto");
      }
    }
  }
}