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
            //repository.Delete(1);
            return null; // repository.Get(2);
        }
    }
}
