using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkolenie.ZadaniaLib;

namespace ZadaniaCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //ObslugaZadan.Obsluga();
            Zadanie z1 = new Zadanie("Zadanie 1");
            Zadanie z2 = new Zadanie("Zadanie 2", DateTime.Now.AddDays(4));

            //Console.WriteLine(z2.DniOpoznienia);

            //Console.WriteLine(z1.OpisZadania());
            //Console.WriteLine(z2.OpisZadania());
            //Console.WriteLine(z1.TerminWykonania);

            ZadanieProjektowe zp1 
                = new ZadanieProjektowe("Pr Task 1", DateTime.Now.AddDays(3));
            Zadanie z3 = zp1;
            Console.WriteLine(zp1.OpisZadania());
            Console.WriteLine(z3.OpisZadania());
            Console.WriteLine("-------------");
            Console.WriteLine(zp1.OpisZadaniaN());
            Console.WriteLine(z3.OpisZadaniaN());

            Console.WriteLine(zp1);
            Console.WriteLine(z3);
            object o = zp1;
            Console.WriteLine(o);


        }
    }


}
