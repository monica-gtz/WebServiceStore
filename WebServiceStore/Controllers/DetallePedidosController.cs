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
    public class DetallePedidosController : ControllerBase
    {
        private readonly ILogger<DetallePedidosController> _logger;
        private readonly DBStoreContext _db;
        public DetallePedidosController(ILogger<DetallePedidosController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/<DetallePedidosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.DetallePedido.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<DetallePedidosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.DetallePedido.SingleOrDefaultAsync(detalle => detalle.DetallePedidoId == id);
                    if (c != null)
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

        // POST api/<DetallePedidosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetallePedido newDetalle)
        {
            try
            {
                using (_db)
                {
                    _db.DetallePedido.Add(newDetalle);
                    await _db.SaveChangesAsync();
                    return Ok(newDetalle);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<DetallePedidosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DetallePedido detalle)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.DetallePedido.SingleOrDefaultAsync(detalle => detalle.DetallePedidoId == id);
                    if (c != null)
                    {
                        c.Price = detalle.Price;
                        c.Cantidad = detalle.Cantidad;
                        c.ProductoId = detalle.ProductoId;
                        c.PedidoId = detalle.PedidoId;

                        await _db.SaveChangesAsync();
                        return Ok(detalle);
                    }
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<DetallePedidosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.DetallePedido.SingleOrDefaultAsync(detalle => detalle.DetallePedidoId == id);
                    if (c != null)
                    {
                        _db.DetallePedido.Remove(c);
                        await _db.SaveChangesAsync();
                        return Ok(id);
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
