using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        static List<PassengerClass> Passengerlist = new List<PassengerClass>()

        {
            new PassengerClass {PassengerId = 100,PassengerName = "mike",PassengerPhone = 11111122 },
            new PassengerClass {PassengerId = 101,PassengerName = "david",PassengerPhone = 22111133 },
            new PassengerClass { PassengerId = 102, PassengerName = "pete", PassengerPhone = 331111144 },
         };
        [HttpGet]
        public IEnumerable<PassengerClass> Get()
        {
            return Passengerlist;
        }
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public PassengerClass Get(int id)
        {
            PassengerClass Obj = Passengerlist.Find(item => item.PassengerId == id);
            return Obj;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public List<PassengerClass>  Post([FromBody] PassengerClass obj)
        {
            Passengerlist.Add(obj);
            return Passengerlist;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public List<PassengerClass>  Put(int id, [FromBody] PassengerClass newObj)
        {
            PassengerClass oldObj = Passengerlist.Find(item => item.PassengerId == newObj.PassengerId);
            Passengerlist.Remove(oldObj);
            Passengerlist.Add(newObj);
            return Passengerlist;
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public List<PassengerClass> Delete(int id)
        {
            PassengerClass obj = Passengerlist.Find(item => item.PassengerId == id);
            bool isRemoved = Passengerlist.Remove(obj);
            return Passengerlist;
        }
    }
}
