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
    public class ProductoCategoriasController : ControllerBase
    {
        private readonly ILogger<ProductoCategoriasController> _logger;
        private readonly DBStoreContext _db;
        public ProductoCategoriasController(ILogger<ProductoCategoriasController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<ProductoCategoriasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (_db)
                {
                    var c = await _db.ProductoCategorias.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<ProductoCategoriasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.ProductoCategorias.SingleOrDefaultAsync(prodcate => prodcate.ProductCategoriaId == id);
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

        // POST api/<ProductoCategoriasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoCategoria prodcate)
        {
            try
            {
                using (_db)
                {
                    _db.ProductoCategorias.Add(prodcate);
                    await _db.SaveChangesAsync();
                    return Ok(prodcate);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<ProductoCategoriasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoCategoria prodcate)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.ProductoCategorias.SingleOrDefaultAsync(prodcate => prodcate.ProductCategoriaId == id);
                    if (c != null)
                    {
                        c.ProductoId = prodcate.ProductoId;
                        c.CategoriaId = prodcate.CategoriaId;

                        await _db.SaveChangesAsync();
                        return Ok(prodcate);
                    }
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ProductoCategoriasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.ProductoCategorias.SingleOrDefaultAsync(prodcate => prodcate.ProductCategoriaId == id);
                    if (c != null)
                    {
                        _db.Remove(c);

                        await _db.SaveChangesAsync();
                        return Ok("BORRADOOOO");
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
