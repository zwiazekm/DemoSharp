using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementyC
{
    class Obliczenia
    {
        //przykład metody statycznej
        public static decimal Dodaj(decimal liczba1, decimal liczba2)
        {
            return liczba1 + liczba2;
        }

        //przykład metody przeciążonej
        public static decimal Dodaj(decimal liczba1, decimal liczba2, decimal liczba3)
        {
            return Dodaj(liczba1, liczba2) + liczba3;
        }

        public static decimal Dodaj(string liczba1, string liczba2)
        {
            decimal l1 = decimal.Parse(liczba1);
            decimal l2 = decimal.Parse(liczba2);
            return l1 + l2;
        }

        public static decimal Dodaj(params decimal[] liczby)
        {
            decimal wynik = 0;
            foreach (var item in liczby)
            {
                wynik += item;
            }
            return wynik;
        }
        
        //Metoda z parametrem opcjonalnym
        public static decimal Srednia(decimal kwota1, decimal kwota2, int sposob=1)
        {
            decimal wynik = 0;
            if (sposob ==1)
            {

            }
            else
            {

            }
            return wynik;
        }

        public static decimal Srednia(int sposob = 1,params decimal[] liczby )
        {
            decimal wynik = 0;
            if (sposob == 1)
            {

            }
            else
            {

            }
            return wynik;
        }
    }
    
}
