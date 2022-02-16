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
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        //private readonly ProductoServices _db;
        public IServices<Categoria> _db;
        private readonly IWebHostEnvironment _host;
        public CategoriaController(ILogger<CategoriaController> logger, IServices<Categoria> db, IWebHostEnvironment host)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var c = await _db.GetById(new Categoria() { CategoriaId = id });
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria newCategoria)
        {
            var categoria = new Categoria();
            try
            {
                categoria = await _db.AddAsync(newCategoria);

                if (categoria.CategoriaId > 0)
                    return Ok(categoria);
                else
                    return BadRequest("No se pudo insertar, revise info");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria updateCategory)
        {
            try
            {
                var existCategory = await _db.GetById(new Categoria() { CategoriaId = id });
                if (existCategory != null)
                {
                    updateCategory.CategoriaId = existCategory.CategoriaId;
                    var update = await _db.UpdateAsync(updateCategory);
                    return Ok(updateCategory);
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
                var existCategory = await _db.GetById(new Categoria() { CategoriaId = id });
                if (existCategory != null)
                {
                    var deleted = await _db.DeleteAsync(existCategory);
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
