using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNBW.Repository
{
    public class DataBaseConnection
    {
        private static string User = "root";
        private static string Password = "admin";
        public static string connString = $"Server=localhost;Database=nbw;Uid={User};Pwd={Password}";
    }
}
