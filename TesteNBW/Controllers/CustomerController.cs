using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        public List<Customer> Get() {
            return repository.Get();
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return repository.Get(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        [HttpPost()]
        public void Post(Customer customer)
        {
            String Billing = customer.Billing.ToString().Replace(",",".");
            repository.Insert(customer.Name, customer.Operation, customer.CNPJ, customer.EmployeeAmont, Billing, customer.PhoneNumber, customer.MobileNumber, customer.Address, customer.District, customer.City, customer.ZipCode, customer.Country);
        }
        
        [HttpPut()]
        public void Put(Customer customer)
        {
            String Billing = customer.Billing.ToString().Replace(",", ".");
            repository.Update(customer.Id, customer.Name, customer.Operation, customer.CNPJ, customer.EmployeeAmont, Billing, customer.PhoneNumber, customer.MobileNumber, customer.Address, customer.District, customer.City, customer.ZipCode, customer.Country);
        }
    }
}
