using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public delegate decimal LiczenieOdsetek(decimal kwota);

    public class Oplata: Zadanie
    {
        public LiczenieOdsetek liczenieOdsetek;
        public event EventHandler PrzySplacie;
        public readonly decimal KwotaNaleznosci;
        public decimal SumaWplat { get; private set; }
        public const string separator = ";";//przykład stałej
        public decimal Odsetki { get; private set; }
        public Oplata(string tytul, DateTime termin, decimal kwota):
            base(tytul, termin)
        {
            KwotaNaleznosci = kwota;
        }

        public decimal Saldo
        {
            get
            {
                return KwotaNaleznosci + Odsetki - SumaWplat;
            }
        }

        public void Splata(decimal kwota)
        {
            SumaWplat += kwota;
            if (PrzySplacie != null && SumaWplat >=KwotaNaleznosci+Odsetki )
            {
                PrzySplacie(this, new EventArgs());
            }
        }

        public void NaliczOdsetki()
        {
            if (liczenieOdsetek != null)
                Odsetki += liczenieOdsetek(Saldo);
        }
        public void NaliczOdsetki2(LiczenieOdsetek liczenie)
        {
            if (liczenie != null)
                Odsetki += liczenie(Saldo);
        }

        public void NaliczOdsetki3(Func<decimal,decimal> liczenie)
        {
            if (liczenie != null)
                Odsetki += liczenie(Saldo);
        }
        public override string OpisZadania()
        {
            return $"ID: {id}, Opłata:{temat}" +
                $", Termin:{planowanyTermin}, Kwota: {KwotaNaleznosci}" +
                $", Saldo:{Saldo}";
        }
    }
}
