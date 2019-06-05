using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public class Oplata: Zadanie
    {
        public readonly decimal KwotaNaleznosci;
        public decimal SumaWplat { get; set; }
        public const string separator = ";";//przykład stałej
        public Oplata(string tytul, DateTime termin, decimal kwota):
            base(tytul, termin)
        {
            KwotaNaleznosci = kwota;
        }
    }
}
