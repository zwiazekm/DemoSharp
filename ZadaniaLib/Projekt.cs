using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public struct Projekt
    {
        public int NrProjektu;
        public string Opis;

        public string NazwaProjektu { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime PlanowanaDataZakonczenia { get; set; }
        
        public Projekt(int nrProjektu, string nazwaProjektu)
        {
            this.NrProjektu = nrProjektu;
            Opis = "";
            NazwaProjektu = nazwaProjektu;
            DataRozpoczecia = DateTime.Today;
            PlanowanaDataZakonczenia = DateTime.Today;
        }

        public override string ToString()
        {
            return $"Projekt nr: {NrProjektu}, {NazwaProjektu}, " +
                $"Początek:{DataRozpoczecia}";
        }
    }
}
