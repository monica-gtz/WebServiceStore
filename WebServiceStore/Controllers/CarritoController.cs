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
    public class CarritoController : ControllerBase
    {
        private readonly ILogger<CarritoController> _logger;
        private readonly DBStoreContext _db;
        public CarritoController(ILogger<CarritoController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<CarritoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Carrito.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Carrito.SingleOrDefaultAsync(carrito => carrito.CarritoId == id);
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

        // POST api/<CarritoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Carrito carrito)
        {
            try
            {
                using (_db)
                {
                    _db.Carrito.Add(carrito);
                    await _db.SaveChangesAsync();
                    return Ok(carrito);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<CarritoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Carrito carrito)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Carrito.SingleOrDefaultAsync(carrito => carrito.CarritoId == id);
                    if (c != null)
                    {
                        c.Cantidad = carrito.Cantidad;
                        c.ProductoId = carrito.ProductoId;
                        c.ClienteId = carrito.ClienteId;

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

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Carrito.SingleOrDefaultAsync(carrito => carrito.CarritoId == id);
                    if (c != null)
                    {
                         _db.Carrito.Remove(c);

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
