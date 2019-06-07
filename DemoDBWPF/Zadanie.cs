using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DemoDBWPF
{
    public class Zadanie
    {
        public int ZadanieID { get; set; }

        public string Tytul { get; set; }
        public DateTime Termin { get; set; }

        public virtual IEnumerable<Osoba> Osoby { get; set; }

        public override string ToString()
        {
            return $"{Tytul} - {Termin}";
        }
    }

    public class Osoba
    {
        public int OsobaID { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public int Wiek { get; set; }

        public virtual Zadanie Zadanie { get; set; }

    }

    public class ZadaniaDB: DbContext
    {
        public DbSet<Zadanie> Zadania { get; set; }
        public DbSet<Osoba> Osoby { get; set; }
    }
}
