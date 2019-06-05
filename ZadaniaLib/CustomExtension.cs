using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public static class CustomExtension
    {
        public static int Razy(this int zm, int ile)
        {
            return zm * ile;
        }

        public static string KrotkiOpis(this Zadanie z)
        {
            return $"{z.Temat} - {z.TerminWykonania.Value.ToShortDateString()}";
        }
    }
}
