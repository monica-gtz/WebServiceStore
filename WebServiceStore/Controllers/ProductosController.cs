using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;
using WebServiceStore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        //private readonly ProductoServices _db;
        public IServices<Producto> _db;
        private readonly IWebHostEnvironment _host;
        public ProductosController(ILogger<ProductosController> logger, IServices<Producto> db, IWebHostEnvironment host)
        {
            _logger = logger;
            _db = db;
            _host = host;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var c = await _db.GetAllAsync();
                return Ok(c);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var c = await _db.GetById(new Producto() { ProductoId = id });
                if (c != null)
                {
                    return Ok(c);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto newProducto)
        {
            var newProduct = new Producto();
            try
            {
                newProduct = await _db.AddAsync(newProducto);

                if (newProduct.ProductoId > 0)
                    return Ok(newProduct);
                else 
                    return BadRequest("No se pudo insertar, revise info");
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        //// PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto updateProduct)
        {
            try
            {
                var existProduct = await _db.GetById(new Producto() { ProductoId = id });
                if (existProduct != null)
                {
                    updateProduct.ProductoId = existProduct.ProductoId;
                    var update = await _db.UpdateAsync(updateProduct);
                    return Ok(updateProduct);
                }
                else
                {
                    return BadRequest("No se pudo editar, revise info");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existProduct = await _db.GetById(new Producto() { ProductoId = id });
                if (existProduct != null)
                {
                    var deleted =  await _db.DeleteAsync(existProduct);
                    return Ok("Borrado!!");
                }
                else
                {
                    return BadRequest("No se pudo eliminar, revise info");
                }

                return NotFound();
               
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
