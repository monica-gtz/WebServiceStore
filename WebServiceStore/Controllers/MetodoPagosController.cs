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
    public class MetodoPagosController : ControllerBase
    {
        private readonly ILogger<MetodoPagosController> _logger;
        private readonly DBStoreContext _db;
        public MetodoPagosController(ILogger<MetodoPagosController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<MetodoPagosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.MetodoPago.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<MetodoPagosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.MetodoPago.SingleOrDefaultAsync(pago => pago.MetodoPagoId == id);
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

        // POST api/<MetodoPagosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MetodoPago pago)
        {
            try
            {
                using (_db)
                {
                    _db.MetodoPago.Add(pago);
                    await _db.SaveChangesAsync();
                    return Ok(pago);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<MetodoPagosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MetodoPago pago)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.MetodoPago.SingleOrDefaultAsync(pago => pago.MetodoPagoId == id);
                    if (c != null)
                    {
                        c.Descripcion = pago.Descripcion;
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

        // DELETE api/<MetodoPagosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.MetodoPago.SingleOrDefaultAsync(pago => pago.MetodoPagoId == id);
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
