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
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly DBStoreContext _db;
        public PedidosController(ILogger<PedidosController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Pedidos.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Pedidos.SingleOrDefaultAsync(pedido => pedido.PedidoId == id);
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

        // POST api/<PedidosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedidos pedido)
        {
            try
            {
                using (_db)
                {
                    _db.Pedidos.Add(pedido);
                    await _db.SaveChangesAsync();
                    return Ok(pedido);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pedidos pedido)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Pedidos.SingleOrDefaultAsync(pedido => pedido.PedidoId == id);
                    if (c != null)
                    {
                        c.Total = pedido.Total;
                        c.ClienteId = pedido.ClienteId;
                        c.MetodoPagoId = pedido.MetodoPagoId;
                        c.DomicilioId = pedido.DomicilioId;

                        await _db.SaveChangesAsync();
                        return Ok(pedido);
                    }
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Pedidos.SingleOrDefaultAsync(pedido => pedido.PedidoId == id);
                    if (c != null)
                    {
                        _db.Remove(c);
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
    }
}
