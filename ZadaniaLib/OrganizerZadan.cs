using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public class OrganizerZadan : IObslugaZadan
    {
        List<Zadanie> listaZadan = new List<Zadanie>();

        public int LiczbaZadan => listaZadan.Count;

        public void DodajZadanie(string temat, DateTime termin)
        {
            Zadanie noweZadanie = new Zadanie(temat, termin);
            listaZadan.Add(noweZadanie);
        }

        public void DodajZadanie(Zadanie noweZadanie)
        {
            listaZadan.Add(noweZadanie);
        }

        public IEnumerable<Zadanie> ListaZadan()
        {
            return listaZadan;
        }

        public Zadanie WyszukajZadanie(string szukanaFraza)
        {
            return listaZadan[0];//TODO: Dorobić wyszukiwanie
        }

        public List<string> ZadaniaNieZakonczone()
        {
            return new List<string>(); //TODO: Dorobić liste zadań
        }
    }
}
