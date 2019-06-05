using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    //Sealed nie można dziedziczy po tej klasie
    public sealed class ZadanieProjektowe: Zadanie
    {
        public string NrZadania { get; set; }
        public string Projekt { get; set; }
        public string Status { get; private set; }
        public DateTime TerminRozpoczecia { get; private set; }
        public ZadanieProjektowe(string temat, DateTime terminPlan):
            base(temat, terminPlan)
        {
            Status = "Planowane";

        }

        private void UstawRozpoczecie(DateTime termin)
        {
            //base.planowanyTermin
        }

        public void ZmienStatus(string nowyStatus)
        {
            //TODO: Dopisac zmiany statusów
        }

        public new string OpisZadaniaN()
        {
            return $"Pr-{id}, T: {temat}, Termin: {planowanyTermin}, " +
                $"Projekt:{Projekt}, Status: {Status}";
        }

        public override string OpisZadania()
        {
            return $"Pr-{id}, T: {temat}, Termin: {planowanyTermin}, " +
               $"Projekt:{Projekt}, Status: {Status}";
        }

        public override string ToString()
        {
            return OpisZadania();
        }
    }
}
