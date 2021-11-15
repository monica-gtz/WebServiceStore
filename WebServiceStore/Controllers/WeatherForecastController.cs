using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebServiceStore.Models;

namespace WebServiceStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly StoreWebSiteContext _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, StoreWebSiteContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult Get()
        {            
            using (_db)
            {
                var result1 = _db.Pedidos.ToList();
                //var result2 = _db.OrderDetails.ToList();
                //var result3 = _db.Client.ToList();
                //var result4 = _db.Products.ToList();
                return Ok(new { result1/*,result2,result3,result4*/});
            }            
        }
    }
}
