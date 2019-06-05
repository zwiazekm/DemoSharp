using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public interface IObslugaZadan
    {
        void DodajZadanie(string temat, DateTime termin);
        void DodajZadanie(Zadanie noweZadanie);

        IEnumerable<Zadanie> ListaZadan();

        Zadanie WyszukajZadanie(string szukanaFraza);

        int LiczbaZadan { get; }


    }
}
