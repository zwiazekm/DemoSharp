using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public interface IWyszukiwanieZadan
    {
        List<string> ZadaniaNieZakonczone();

        List<string> ZadaniaPrzeterminowane();
        Zadanie WyszukajZadanie(string szukanaFraza);

    }
}
