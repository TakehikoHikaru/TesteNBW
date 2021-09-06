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
    public class CustomerController : System.Web.Http.ApiController
    {

        CustomerRepository repository;
        CountryRepository CountryRepository;

        public CustomerController() {
            repository = new CustomerRepository();
            CountryRepository = new CountryRepository();
        }

        [HttpGet]
        public Customer Get() {
            repository.Insert("Name", "Operation", "234234", 2, "2.21", "Phone", "Mobile", "address", "District", "City", "ZipCode", CountryRepository.Get(2));
            //repository.Delete(9);
            return repository.Get(10);
        }
    }
}
