using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication2.Controllers
{

    [ApiController]
    [System.Web.Http.Route("[controller]")]
    public class CustomerController : ApiController
    {
        [Microsoft.AspNetCore.Mvc.Route("/2")]
        public String Get(int id) {
            return "uauahduauahnd";
        }
    }
}
