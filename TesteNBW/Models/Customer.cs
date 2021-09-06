using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNBW.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Operation { get; set; }
        public String CNPJ { get; set; }
        public int EmployeeAmont { get; set; }
        public Decimal Billing { get; set; }
        public String PhoneNumber { get; set; }
        public String MobileNumber { get; set; }
        public String Address { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
        public Country Country { get; set; }


    }
}
