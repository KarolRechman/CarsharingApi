using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CarsharingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsharingController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CarsharingController> _logger;

        public CarsharingController(ILogger<CarsharingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            

            using (var connection = new MySqlConnection("server=remotemysql.com;port=3306;database=vNB3Rw2pVo;user=vNB3Rw2pVo;password=TEXnbd23EV;"))
            {
              return  connection.Query<dynamic>("SELECT * FROM vNB3Rw2pVo.new_table;").ToArray();
            }
        }
    }
}
