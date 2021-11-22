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
    public class EstatusController : ControllerBase
    {

        private readonly ILogger<EstatusController> _logger;
        private readonly DBStoreContext _db;
        public EstatusController(ILogger<EstatusController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/<EstatusController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Estatus.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<EstatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Estatus.SingleOrDefaultAsync(estatus => estatus.EstatusId == id);
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

        // POST api/<EstatusController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estatus estatus)
        {
            try
            {
                using (_db)
                {
                    _db.Estatus.Add(estatus);
                    await _db.SaveChangesAsync();
                    return Ok(estatus);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<EstatusController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Estatus update)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Estatus.SingleOrDefaultAsync(actualizar => actualizar.EstatusId == id);
                    if (c != null)
                    {
                        c.Description = update.Description;

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

        // DELETE api/<EstatusController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Estatus.SingleOrDefaultAsync(estatus => estatus.EstatusId == id);
                    if (c != null)
                    {
                        _db.Estatus.Remove(c);
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
