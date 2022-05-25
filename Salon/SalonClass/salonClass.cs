using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salon.SalonClass
{
    internal class salonClass
    {
        public int ID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string Pesel { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
    }
}
