using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using AppBurgers.Core.Entities;
using AppBurgers.Infrastructure.Data;
using AppBurgers.Infrastructure.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBurgers.Api.Controllers
{
    [Route("api/v1/Appburger/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppBurgerContext _context;
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new AppBurgerContext());


        [HttpGet]
        public IActionResult GetProducts()
        {
            var product = _unitOfWork.Producto.Get();
            if (product != null)
            {
                return Ok(product);

            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var product = _unitOfWork.Producto.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Producto.Insert(producto);
                    _unitOfWork.Save();
                    return Created("Appburger/create", producto);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(producto);
        }

        [HttpPut]
        public IActionResult UpdateUser(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Producto.Update(producto);
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
                _unitOfWork.Producto.Delete(id);
                _unitOfWork.Save();
                return Ok("Producto eliminado..");
            }
            else
            {
                return BadRequest("Usuario con id incorrecto");
            }
        }
    }
}