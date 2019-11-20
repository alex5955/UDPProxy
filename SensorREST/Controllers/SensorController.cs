using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace SensorREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        public static List<SensorData> SensorList = new List<SensorData>()
        {
            new SensorData(1, "TestNavn", 30, 500)
        };

        // GET: api/Sensor
        [HttpGet]
        public IEnumerable<SensorData> Get()
        {
            return SensorList;
        }

        // GET: api/Sensor/5
        [HttpGet("{id}", Name = "Get")]
        public SensorData Get(int id)
        {
            return SensorList.Find(s => s.Id == id);
        }

        // POST: api/Sensor
        [HttpPost]
        public void Post([FromBody] SensorData value)
        {
            SensorList.Add(value);
        }

        //// PUT: api/Sensor/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
