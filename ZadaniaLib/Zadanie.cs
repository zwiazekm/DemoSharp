using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public class Zadanie
    {
        private static int ostatnieId;
        private int id;
        private string temat;
        private DateTime planowanyTermin;
        private bool wykonane;

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

        public string OpisZadania()
        {
            return $"ID: {id}, Temat: {temat}," +
                $" Termin: {planowanyTermin.ToShortDateString()}, " +
                $"Wyknane:{wykonane}";
        }

        public void Zakoncz()
        {
            wykonane = true;
            TerminWykonania = DateTime.Today;
        }

        //property
        public string Temat
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

