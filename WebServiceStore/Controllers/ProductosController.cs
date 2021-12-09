﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;
using WebServiceStore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly DBStoreContext _db;
        private readonly IWebHostEnvironment _host;
        public ProductosController(ILogger<ProductosController> logger, DBStoreContext db, IWebHostEnvironment host)
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
                using (_db)
                {
                    var c = await _db.Producto.ToListAsync();
                    return Ok(c);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Producto.SingleOrDefaultAsync(producto => producto.ProductoId == id);
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

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto newProduct)
        {
            try
            {
                using (_db)
                {
                    _db.Producto.Add(newProduct);

                    await _db.SaveChangesAsync();
                    return Ok(newProduct);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ProductosController>
        [HttpGet("GetAddProductNew")]
        public async Task<IActionResult> GetAddProductView()
        {
            var result = new AddProductView();
            try
            {
                //Regresar add product view estatus y categoria 
                using (_db)
                {
                   result.ListaCategoria = await _db.Categoria.ToListAsync();
                    result.ListaEstatus = await _db.Estatus.ToListAsync();
                    
                    return Ok(result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ProductosController>
        [HttpPost("addProductNew")]
        public async Task<IActionResult> AddNewProduct([FromBody] AddProductView newProduct)
        {
            try
            {
                var p = new Producto();
                p.Nombre = newProduct.Nombre;
                p.Precio = newProduct.Precio;
                p.Imagen = newProduct.Imagen;
                p.EstatusId = newProduct.EstatusSelected.EstatusId;

                var pc = new ProductoCategoria();
                pc.CategoriaId = newProduct.CategoriaSelected.CategoriaId;
              

                using (_db)
                {
                    _db.Producto.Add(p);
                    
                    await _db.SaveChangesAsync();

                    pc.ProductoId = p.ProductoId;
                    _db.ProductoCategorias.Add(pc);
                    _db.SaveChanges();
                    newProduct.ProductoId = p.ProductoId;
                    return Ok(newProduct);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto update)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Producto.SingleOrDefaultAsync(update => update.ProductoId == id);
                    if(c != null)
                    {
                        c.Nombre = update.Nombre;
                        c.Precio = update.Precio;
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

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (_db)
                {
                    var c = await _db.Producto.SingleOrDefaultAsync(producto => producto.ProductoId == id);
                    if(c != null)
                    {
                        _db.Producto.Remove(c);
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

        [HttpPost("image")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SubirArchivo()
        {
            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files[0];
                if(file == null)
                {
                    return BadRequest("No file found");
                }
                var filename = Guid.NewGuid() + ".jpg";

                try
                {
                    _logger.LogInformation("Uploading product image");
                    var filePath = Path.Combine(_host.WebRootPath, "Images", filename);
                    Console.WriteLine(Directory.CreateDirectory(Path.GetDirectoryName(filePath)));
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    if (file.Length > 0)
                    {
                        await using var stream = new FileStream(filePath, FileMode.Create);
                        await file.CopyToAsync(stream);
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest(new { ex.Message, ex.StackTrace });
                }
                return Ok(new Producto() { Imagen = @"/images/" + filename });
            }
            else
            {
                return BadRequest("No file found, Request doesn't contain a file");
            }
        }
    }
}
