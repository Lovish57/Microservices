using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {


        static List<DriverClass> driverlist = new List<DriverClass>()
          {
                new DriverClass { DriverId = 100, DriverName = "Jones", DriverPhone = 11111111 },
            new DriverClass { DriverId = 101, DriverName = "Ben", DriverPhone = 22111111 },
            new DriverClass { DriverId = 102, DriverName = "Joseph", DriverPhone = 33111111 },
         };
        [HttpGet]
        public IEnumerable<DriverClass> Get()
        {
          

            return driverlist;

        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public DriverClass Get(int id)
        {

            DriverClass Obj = driverlist.Find(item => item.DriverId == id);
            return Obj;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public List<DriverClass> Post([FromBody] DriverClass obj)
        {
            driverlist.Add(obj);
            return driverlist;
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public List<DriverClass> Put([FromBody] DriverClass newobj)
        {
            DriverClass Obj = driverlist.Find(item => item.DriverId == newobj.DriverId);
            driverlist.Remove(Obj);
            driverlist.Add(newobj);
            return driverlist;

        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public List<DriverClass> Delete(int id)
        {   DriverClass obj=driverlist.Find(item => item.DriverId == id);
            bool isRemoved = driverlist.Remove(obj);
            return driverlist;

        }
    }
}
