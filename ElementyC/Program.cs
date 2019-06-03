using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementyC
{
    class Program
    {
        static void Main(string[] args)
        {
            //OpertoryIZmienne();
            //Konwersja();
            //FunkcjeWarunkowe();
            //Pętle();
            //Tablice();
            //WywolaniaMetod();
            try
            {
                MetodaZBledem();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Po catch main");
        }

        public static void MetodaZBledem()
        {
            try
            {
                Console.Write("Podaj liczbe:");
                string strLiczba = Console.ReadLine();
                decimal decLiczba = decimal.Parse(strLiczba);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //catch(OverflowException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Console.WriteLine("Po catch");
        }

        private static void WywolaniaMetod()
        {
            //Wywołanie metody
            decimal wynik = Obliczenia.Dodaj(123, 45);
            wynik = Obliczenia.Dodaj(34.3M, 45.1M, 12);
            wynik = Obliczenia.Dodaj("23,4", "12");
            wynik = Obliczenia.Dodaj(new decimal[] { 12, 45.2M, 124.45M, 67 });
            decimal[] liczby = { 12, 45.2M, 124.45M, 67 };
            wynik = Obliczenia.Dodaj(liczby);
            wynik = Obliczenia.Dodaj(123, 53.2M, 35.56M, 23, 52.67M);
            wynik = Obliczenia.Srednia(12, 24);
            wynik = Obliczenia.Srednia(56, 2M, 45M, 56M);
            wynik = Obliczenia.Srednia(kwota1: 45, kwota2: 41, sposob: 2);
        }

        static void Tablice()
        {
            //deklaracja tablicy
            int[] liczby = new int[5]; //tablica jednowymiarowa 5'cio elementowa
            //Array tab = Array.CreateInstance(typeof(int), 5);
            int[,] tabela = new int[4, 3]; //tablica dwuwymiarowa
            liczby[0] = 23;
            tabela[1, 2] = 4;
            int[] liczby2 = { 12, 41, 41, 12,52};
            object[] objTab = { "test", 123, DateTime.Now };
            foreach (var item in tabela)
            {
                Console.WriteLine(item);
            }
            Array.Resize(ref liczby, 9);
        }
        
        static void Pętle()
        {
            //For
            for (int i = 0, j=20; i < 20; i+=2, j--)
            {
                if (j == 15)
                    continue; //Przejście do następnego kroku

                Console.WriteLine($"i={i}, j={j}");

                if (j == 3)
                    break; //Wyjdź z pętli
            }

            //While
            int z = 0;
            while (z<10)
            {
                Console.WriteLine(z++);
            }

            //do
            do
            {
                Console.WriteLine(z--);
            } while (z>0);

            //foreach
            string[] linie = new string[3];
            foreach (var linia in linie)
            {
                Console.WriteLine(linia);
            }
        }

        private static void FunkcjeWarunkowe()
        {
            int liczba = 20;
            string wynikSprawdzania = "";
            //if
            if (liczba >10)
            {
                wynikSprawdzania = "JEst wieksza od 10";
            }
            else if (liczba < 10 && liczba >=5)
            {
                wynikSprawdzania = "Jest z przedzialu 5-10";
            }
            else
            {
                wynikSprawdzania = "Jest mniejsza niz 5";
            }

            //switch
            switch (liczba)
            {
                case 10:
                    Console.WriteLine("Liczba jest 10");
                    return;
                case 20:
                    Console.WriteLine("Liczba jest 20");
                    goto case 10;
                case 30:
                case 40:
                    Console.WriteLine("Liczba jest 30 lub 40");
                    break;
                default:
                    Console.WriteLine("Pozostała liczba");
                    break;
            }

        }

        private static void Konwersja()
        {
            //Konwersja niejawna
            int a = 10;
            long b = a; //z int na long
            //Konwersja jawna
            int c = (int)b;//operator rzutowania

            string opisLiczby = b.ToString();

            decimal dec = 23.5M; //M oznacza przypisanie decimal
            a = Convert.ToInt32(dec);//Uzycie klasy konwert
            Console.WriteLine($"a={a}");

            string strLiczba = "23,5";
            decimal decZstr = decimal.Parse(strLiczba);
            decZstr += 10M;
            opisLiczby = "Nowa wartość decimal =" + decZstr;
            Console.WriteLine(opisLiczby);

            //Prosze o liczbe uzytkownika
            Console.Write("Podaj liczbe:");
            strLiczba = Console.ReadLine(); //readline zwaraca string
            //decZstr = decimal.Parse(strLiczba);
            //Console.WriteLine($"Liczba wpisana to: {decZstr}");

            bool czyJestOk = decimal.TryParse(strLiczba, out decZstr);
            if (!czyJestOk)
            {
                Console.WriteLine("Bledna liczba");
            }
            else
            {
                Console.WriteLine($"Liczba wpisana to: {decZstr}");
            }


            Object obj = a; //Boxing
            b = (int)obj; //Unboxing
            Console.WriteLine($"Wartość b={b}");

            var zm1 = "Test"; //Deklaracja przez var

            dynamic dyn; //Deklaracja typu dynamic
            dyn = "Test";
            dyn = 12;

            //Opracje na string
            string demoStr = "To jest przyklad";
            demoStr += "\nDruga linia";

            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendLine("Pierwsza linia");
            strBuild.AppendLine("Druga linia");
            Console.WriteLine(strBuild);

        }

        private static void OpertoryIZmienne()
        {
            //Nazwa zmiennej: nie może zaczya się od cyfry, nie może mieć spacji, nie może być nazwą kluczowe, 
            //nazwy metod podobnie.

            // Operatory
            /* 
             * Arytmetyczne + - * / %
             * Inkrementacja ++, --
             * Konkatenacja +
             * Przypisania =, +=, -=, *=
             * Porównania ==, !=, <, >, <=, >=, is (tylko klasy)
             * logiczne &, &&, |, ||, !
             * Warunkowy (przykład operatora terarnego: ?:
             * */
            int a = 10, b; //deklaracja zmienej
            int c;
            //inkrementacja demo
            b = a++; //Najpierw uzycie potem powiekszenie
            c = ++a; //Najpierw powiekszenie potem uzycie
            Console.WriteLine("Wartość b={0}, c={1}", b, c);
            Console.WriteLine($"Wartość b={b}, c={c}");
            //Konkatenacja
            string txt1 = "Hello";
            string txt2 = "C#";
            Console.WriteLine(txt1 + " " + txt2);
            //przypisanie
            c += 20; c = c + 20;
            txt1 += " World";
            //przyklad warunkowe operatora
            string wynik = (c > 10 && c <= 50) ? "Jest OK" : "Kiepsko";
            //można tak
            if (c > 10 && c <= 50)
                wynik = "Jest ok w IF";
            else
                wynik = "Kiepso w IF";
        }
    }
}
