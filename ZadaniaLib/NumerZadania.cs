using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public struct NumerZadania
    {
        public int nr;
        public string sufix;
        public const char selektor = '/';

        public NumerZadania(int nr, string sufix)
        {
            this.nr = nr;
            this.sufix = sufix;
        }

        public override string ToString()
        {
            return $"{nr}{selektor}{sufix}";
        }

        public static implicit operator NumerZadania(string strNr)
        {
            return new NumerZadania(0, strNr);
        }
    }
}
