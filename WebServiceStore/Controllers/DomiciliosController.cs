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
    public class DomiciliosController : ControllerBase
    {
        private readonly ILogger<DomiciliosController> _logger;
        private readonly DBStoreContext _db;
        public DomiciliosController(ILogger<DomiciliosController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<DomiciliosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Domicilio.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // GET api/<DomiciliosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Domicilio.SingleOrDefaultAsync(domicilio => domicilio.DomicilioId == id);
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

        // POST api/<DomiciliosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domicilio domicilio)
        {
            try
            {
                using (_db)
                {
                    _db.Domicilio.Add(domicilio);
                    await _db.SaveChangesAsync();
                    return Ok(domicilio);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<DomiciliosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Domicilio domicilio)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Domicilio.SingleOrDefaultAsync(domicilio => domicilio.DomicilioId == id);
                    if (c != null)
                    {
                        c.CodigoPostal = domicilio.CodigoPostal;
                        c.Calle = domicilio.Calle;
                        c.Colonia = domicilio.Colonia;
                        c.Ciudad = domicilio.Ciudad;
                        c.Estado = domicilio.Estado;
                        c.Pais = domicilio.Pais;
                        c.NumExt = domicilio.NumExt;
                        c.ClienteId = domicilio.ClienteId;

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

        // DELETE api/<DomiciliosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Domicilio.SingleOrDefaultAsync(domicilio => domicilio.DomicilioId == id);
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
