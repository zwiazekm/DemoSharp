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
        public NumerZadania NrZadania { get; set; }
        public Projekt ZadanieProjektu { get; set; }
        public StatusZadania Status { get; private set; }
        public DateTime TerminRozpoczecia { get; private set; }

        public ZadanieProjektowe(string temat, DateTime terminPlan):
            base(temat, terminPlan)
        {
            Status = StatusZadania.Planowane;
        }

        private void UstawRozpoczecie(DateTime termin)
        {
            //base.planowanyTermin
        }

        public void ZmienStatus(StatusZadania nowyStatus)
        {
            var nrStatusu = (int)nowyStatus;
            if (nrStatusu<-1 || nrStatusu >2)
            {
                throw new IndexOutOfRangeException("Wartośc z poza zakresu");
            }
            Status = nowyStatus;
        }

        public new string OpisZadaniaN()
        {
            return $"Pr-{id}, T: {temat}, Termin: {planowanyTermin}, " +
                $"Projekt:{ZadanieProjektu}, Status: {Status}";
        }

        public override string OpisZadania()
        {
            return $"Pr-{id}, T: {temat}, Termin: {planowanyTermin}, " +
               $"Projekt:{ZadanieProjektu}, Status: {Status}";
        }

        public override string ToString()
        {
            return OpisZadania();
        }
    }
}
