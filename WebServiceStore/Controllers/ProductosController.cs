using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly DBStoreContext _db;
        public ProductosController(ILogger<ProductosController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Producto.ToListAsync();
                    return Ok(c);
                }
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
                using (_db)
                {
                    var c = await _db.Producto.SingleOrDefaultAsync(producto => producto.ProductoId == id);
                    if(c != null)
                    {
                        return Ok(c);
                    }
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto newProduct)
        {
            try
            {
                using (_db)
                {
                    _db.Producto.Add(newProduct);
                    await _db.SaveChangesAsync();
                    return Ok(newProduct);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto update)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Producto.SingleOrDefaultAsync(update => update.ProductoId == id);
                    if(c != null)
                    {
                        c.Nombre = update.Nombre;
                        c.Precio = update.Precio;
                        c.Imagen = update.Imagen;
                        c.EstatusId = update.EstatusId;

                        await _db.SaveChangesAsync();
                        return Ok(c);
                    }
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Producto.SingleOrDefaultAsync(producto => producto.ProductoId == id);
                    if(c != null)
                    {
                        _db.Producto.Remove(c);
                        await _db.SaveChangesAsync();
                        return Ok("Borrado");
                    }
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
