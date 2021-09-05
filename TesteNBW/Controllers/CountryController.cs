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
        [HttpGet]
        public String Get()
        {
            CountryRepository repository = new CountryRepository();
            repository.Get();
            return "Aaaaa";
        }
    }
}
