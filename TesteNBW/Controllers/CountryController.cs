using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNBW.Models;
using TesteNBW.Repository;

namespace TesteNBW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : System.Web.Http.ApiController
    {

        CountryRepository repository;

        public CountryController() {
            repository = new CountryRepository();
        }

        [HttpGet]
        public List<Country> Get()
        {
            return repository.Get();
        }

        [HttpGet("id")]
        public Country Get(int id) {
            return repository.Get(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        [HttpPost]
        public void Post(Country country) {
            repository.Insert(country.Acronym, country.Descryption);
        }

        [HttpPut]
        public void Put(Country country)
        {
            repository.Update(country.Id,country.Acronym, country.Descryption);
        }
    }
}
