using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;

namespace WebServiceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : ControllerBase
    {
        private readonly ILogger<EstatusController> _logger;
        //private readonly ProductoServices _db;
        public IServices<Estatus> _db;
        private readonly IWebHostEnvironment _host;
        public EstatusController(ILogger<EstatusController> logger, IServices<Estatus> db, IWebHostEnvironment host)
        {
            _logger = logger;
            _db = db;
            _host = host;
        }

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estatus newEstatus)
        {
            var estatus = new Estatus();
            try
            {
                estatus = await _db.AddAsync(newEstatus);

                if (estatus.EstatusId > 0)
                    return Ok(estatus);
                else
                    return BadRequest("No se pudo insertar, revise info");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var c = await _db.GetById(new Estatus() { EstatusId = id });
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Estatus updateEstatus)
        {
            try
            {
                var existEstatus = await _db.GetById(new Estatus() { EstatusId = id });
                if (existEstatus != null)
                {
                    updateEstatus.EstatusId = existEstatus.EstatusId;
                    var update = await _db.UpdateAsync(updateEstatus);
                    return Ok(updateEstatus);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existEstatus = await _db.GetById(new Estatus() { EstatusId = id });
                if (existEstatus != null)
                {
                    var deleted = await _db.DeleteAsync(existEstatus);
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
