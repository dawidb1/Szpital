using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szpital.Models
{
    public class Pracownik
    {
        public int PracownikID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Oddzial { get; set; }
        public StopienEnum Stopien { get; set; }
    }
}