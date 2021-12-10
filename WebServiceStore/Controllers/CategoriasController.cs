using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;
using WebServiceStore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<CategoriasController> _logger;
        private readonly DBStoreContext _db;
        public CategoriasController(ILogger<CategoriasController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Categoria.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Categoria.SingleOrDefaultAsync(categoria => categoria.CategoriaId == id);
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

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                using (_db)
                {
                    _db.Categoria.Add(categoria);
                    await _db.SaveChangesAsync();
                    return Ok(categoria);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAddCategorie")]
        public async Task<IActionResult> GetAddCategorieView()
        {
            var result = new AddCategorieView();
            try
            {
                //Regresar add categorie view estatus
                using (_db)
                {
                    result.ListaEstatus = await _db.Estatus.ToListAsync();

                    return Ok(result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<CategoriasController>
        [HttpPost("addCategorieNew")]
        public async Task<IActionResult> AddNewCategorie([FromBody] AddCategorieView newCategorie)
        {
            try
            {
                var cat = new Categoria();
                cat.Descripcion = newCategorie.Descripcion;
                cat.Imagen = newCategorie.Imagen;
                
                cat.EstatusId = newCategorie.EstatusSelected.EstatusId;
                using (_db)
                {
                    _db.Categoria.Add(cat);

                    await _db.SaveChangesAsync();
                    return Ok(newCategorie);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria update)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Categoria.SingleOrDefaultAsync(update => update.CategoriaId == id);
                    if(c != null)
                    {
                        c.Descripcion = update.Descripcion;
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

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Categoria.SingleOrDefaultAsync(categoria => categoria.CategoriaId == id);
                    if(c != null)
                    {
                        _db.Categoria.Remove(c);
                        await _db.SaveChangesAsync();
                        return Ok("BORRADO");
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
