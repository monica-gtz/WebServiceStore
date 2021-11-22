﻿using Microsoft.AspNetCore.Mvc;
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
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly DBStoreContext _db;
        public ClientesController(ILogger<ClientesController> logger, DBStoreContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (_db)
            {
                var c = await _db.Cliente.ToListAsync();
                return Ok(c);
            }
            
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (_db)
            {                
                return Ok(await _db.Cliente.SingleOrDefaultAsync(cliente => cliente.ClienteId == id));
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente newCliente)
        {
            using (_db)
            {
                _db.Cliente.Add(newCliente);
                await _db.SaveChangesAsync();
                return Ok(newCliente);
            }
            
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente actualizar)
        {
            using (_db)
            {
                var c = await _db.Cliente.SingleOrDefaultAsync(actualizar => actualizar.ClienteId == id);
                if (c != null)
                {
                    c.Nombre = actualizar.Nombre;
                    c.Telefono = actualizar.Telefono;
                    c.Mail = actualizar.Mail;

                    await _db.SaveChangesAsync();
                    
                }
                return Ok(actualizar);
            }            
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (_db)
            {
                var c = await _db.Cliente.SingleOrDefaultAsync(cliente => cliente.ClienteId == id);
                if( c != null)
                {
                    _db.Cliente.Remove(c);
                    await _db.SaveChangesAsync();
                }
                return Ok(id);
            }
        }
    }
}
