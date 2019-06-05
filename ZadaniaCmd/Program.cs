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
            //Zadanie z1 = new Zadanie("Zadanie 1");
            //Zadanie z2 = new Zadanie("Zadanie 2", DateTime.Now.AddDays(4));

            //Console.WriteLine(z2.DniOpoznienia);

            //Console.WriteLine(z1.OpisZadania());
            //Console.WriteLine(z2.OpisZadania());
            //Console.WriteLine(z1.TerminWykonania);

            //ZadanieProjektowe zp1 
            //    = new ZadanieProjektowe("Pr Task 1", DateTime.Now.AddDays(3));
            //Zadanie z3 = zp1;
            //Console.WriteLine(zp1.OpisZadania());
            //Console.WriteLine(z3.OpisZadania());
            //Console.WriteLine("-------------");
            //Console.WriteLine(zp1.OpisZadaniaN());
            //Console.WriteLine(z3.OpisZadaniaN());

            //Console.WriteLine(zp1);
            //Console.WriteLine(z3);
            //object o = zp1;
            //Console.WriteLine(o);

            //StatusZadania st = StatusZadania.Anulowane;
            //Console.WriteLine(st);

            //Projekt pr1;
            //pr1.NrProjektu = 1;
            //pr1.Opis = "Test";

            // pr1.NazwaProjektu = "Test Projekt 1";
            //pr1.DataRozpoczecia = DateTime.Now.AddMonths(-2);
            //pr1.PlanowanaDataZakonczenia = DateTime.Now.AddMonths(1);

            //Projekt pr2 = new Projekt()
            //{
            //    NrProjektu = 2,
            //    Opis = "Test",
            //    NazwaProjektu = "Test projekt 2",
            //    DataRozpoczecia = DateTime.Now.AddMonths(-2),
            //    PlanowanaDataZakonczenia = DateTime.Now.AddMonths(1)
            //};

            //Projekt pr3 = new Projekt(3, "Test 3");


            //Console.WriteLine(pr2.NazwaProjektu);
            //Console.WriteLine(pr3.NazwaProjektu);

            //NumerZadania nr1 = new NumerZadania(1, "Proj1");

            //NumerZadania nr2 = "124/pROJ1";
            //nr2.nr = 2;
            ////nr2.sufix = "Prj";

            //Console.WriteLine(nr1);
            //Console.WriteLine(nr2);

            //Oplata op1 = new Oplata("Platnosc1", 
            //    DateTime.Now.AddDays(-2), 230);
            //op1.liczenieOdsetek += MojeOdsetki;
            //op1.liczenieOdsetek += kw => kw * 0.2M;
            //op1.PrzySplacie += Op1_PrzySplacie;
            //op1.Splata(30);
            //op1.NaliczOdsetki();
            //op1.NaliczOdsetki2(MojeOdsetki);
            //op1.NaliczOdsetki2(kw => kw * 0.2M);
            //op1.NaliczOdsetki3(kw => kw * 0.4M);
            //Console.WriteLine(op1.OpisZadania());
            //op1.Splata(500);
            //Console.WriteLine(op1.OpisZadania());

        }

        private static void Op1_PrzySplacie(object sender, EventArgs e)
        {
            Console.WriteLine("Splacono");
        }

        static decimal MojeOdsetki(decimal kwota)
        {
            return kwota * 0.2M;
        }
    }


}
