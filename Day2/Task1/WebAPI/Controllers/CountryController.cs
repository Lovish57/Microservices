using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    
        [RoutePrefix("api/Country")]
        public class CountryController : ApiController
        {
            static List<Country> Countrylist = new List<Country>()
        {
            new Country{Id=1, Countryname="USA",Capital="Washington DC"},
            new Country{Id=2, Countryname="CHINA",Capital="Beijing"},
            new Country{Id=3, Countryname="India",Capital="Delhi"},
            new Country{Id=4, Countryname="South Africa",Capital="Cape Town"},
        };

            [HttpGet]
            public List<Country> Get()
            {
                return Countrylist;
            }

            [HttpGet]
            [Route("{Id}")]
            public Country GetCountryById(int id)
            {
                Country CountryObj = Countrylist.Find(item => item.Id == id);
                return CountryObj;
            }

            [HttpGet]
            [Route("Capital/{Capital}")]
            public IEnumerable<Country> GetAllCountryByCapitalName(string capital)
            {
                IEnumerable<Country> capitalList = Countrylist.Where(item => item.Capital.Equals(capital));
                return capitalList;
            }

            [HttpGet]
            [Route("CountryName/{CountryName}")]
            public Country GetCountryByName(string CountryName)
            {
                Country obj = Countrylist.SingleOrDefault(item => item.Countryname.Equals(CountryName));
                return obj;
            }

            [HttpGet]
            [Route("CountryNameById/{Id}")]
            public IHttpActionResult GetCountryName(int id)
            {
                Country CountryObj = Countrylist.Find(item => item.Id == id);
                if (CountryObj != null)
                {
                    return Ok(CountryObj.Countryname);
                }
                return NotFound();
            }


            [HttpPost]
            public List<Country> Post([FromBody] Country obj)
            {
                Countrylist.Add(obj);
                return Countrylist;
            }

            [HttpPut]
            [Route("{Id}")]
            public void Put([FromBody] Country newObj)
            {
                Country oldObj = Countrylist.Find(item => item.Id == newObj.Id);
                Countrylist.Remove(oldObj);
                Countrylist.Add(newObj);
            }

            [HttpDelete]
            [Route("{Id}")]
            public IHttpActionResult Delete(int id)
            {
                Country obj = Countrylist.Find(item => item.Id == id);
                if (obj != null)
                {
                    bool isRemoved = Countrylist.Remove(obj);
                    if (isRemoved)
                    {
                        return Ok(obj);
                    }
                }
                return NotFound();
            }

        }
    
}