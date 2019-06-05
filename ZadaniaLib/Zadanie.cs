using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public class Zadanie: Element
    {
        protected DateTime planowanyTermin;
               
        static Zadanie()
        {
            //Console.WriteLine("Konstruktor statyczny");
            generatorID();
        }

        //Konstruktor
        public Zadanie(string temat)
        {
            id = ++ostatnieId;
            this.temat = temat;
            planowanyTermin = DateTime.Now.AddDays(1);
        }

        public Zadanie(string temat, DateTime termin)
        {
            id = ++ostatnieId;
            this.temat = temat;
            planowanyTermin = termin;
        }

        private static void generatorID()
        {
            ostatnieId = 100;
        }

        public virtual string OpisZadania()
        {
            return $"ID: {id}, Temat: {temat}," +
                $" Termin: {planowanyTermin.ToShortDateString()}, " +
                $"Wyknane:{wykonane}";
        }

        public string OpisZadaniaN()
        {
            return $"ID: {id}, Temat: {temat}," +
                $" Termin: {planowanyTermin.ToShortDateString()}, " +
                $"Wyknane:{wykonane}";
        }

        public override void Zakoncz()
        {
            base.Zakoncz(); //Wywołanie metody bazowej
            TerminWykonania = DateTime.Today;
        }
        //implementacja metody abstrakcyjnej
        public override string Info()
        {
            return OpisZadania();
        }

        //property implementacja property virtual
        public override string Temat
        {
            get { return temat; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Tekst nie może być pusty");
                }
                temat = value;
            }
        }

        public DateTime PlanowanyTermin
        {
            get { return planowanyTermin; }
        }
        //public DateTime PlanowanyTermin => planowanyTermin;

        public int DniOpoznienia
        {
            get
            {
                int ldni = DateTime.Today.Subtract(planowanyTermin).Days;
                ldni = (ldni < 0) ? 0: ldni;
                return ldni;
            }
        }

        public DateTime? TerminWykonania { get; set; }
    }
}

