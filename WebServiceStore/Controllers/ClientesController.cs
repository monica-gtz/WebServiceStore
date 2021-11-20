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
            var c =await _db.Cliente.ToListAsync();
            return Ok(c);
            
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var c = _db.Cliente.SingleOrDefaultAsync(cliente => cliente.ClienteId == id);
            return "Value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente newCliente)
        {
            var c = _db.Cliente.AddAsync(newCliente);
            _db.SaveChangesAsync();
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //var c = _db.Cliente

            
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
