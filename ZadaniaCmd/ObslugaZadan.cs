using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ZadaniaCmd
{
    internal class ObslugaZadan
    {
        //private static string[] zadania = new string[5];
        private static List<string> zadania = new List<string>();
        //ArrayList z = new ArrayList();

        internal static void Menu()
        {
            string lista = "1. Nowe zadanie\n" +
                "2. Usuń zadanie\n" +
                "3. Lista zadań\n" +
                "0. Koniec programu";

            Console.Clear();
            Console.WriteLine("Wybór opcji:");
            Console.WriteLine(lista);
        }

        internal static void Obsluga()
        {
            do
            {
                Menu();
                string wybor = OdbierzDane("Wybierz akcję");
                switch (wybor)
                {
                    case "1":
                        NoweZadanie();
                        break;
                    case "2":
                        UsunZadanie();
                        break;
                    case "3":
                        ListaZadan();
                        break;
                    case "0":
                        Console.WriteLine("Koniec");
                        return;
                    default:
                        Console.WriteLine("Zły wybór.");
                        break;
                }
                OdbierzDane("Wciśnij <ENTER>", false);
            } while (true);
        }


        internal static string OdbierzDane(string komunikat, bool pokazZnak = true)
        {
            string info = $"{komunikat}";
            if (pokazZnak)
                info += ":";

            Console.Write(info);
            return Console.ReadLine();
        }

        internal static void NoweZadanie()
        {
            Console.WriteLine("Podaj dane nowego zadania.");
            string temat = OdbierzDane("Temat");
            string terminStr = OdbierzDane("Termin wykonania");
            DateTime termin;
            if (!DateTime.TryParse(terminStr, out termin)
                || string.IsNullOrEmpty(temat))
            {
                Console.WriteLine("Błędne dane do zadania!!!");
                return;
            }
            //Dodanie do listy zadań
            zadania.Add($"Temat: {temat}, Termin: {termin.ToShortDateString()}");
        }

        private static void ListaZadan()
        {
            int nrPozycji = 1;
            Console.WriteLine("Lista zadań:");
            foreach (var zadanie in zadania)
            {
                Console.WriteLine($"{nrPozycji++} - {zadanie}");
            }
        }

        private static void UsunZadanie()
        {
            ListaZadan();
            try
            {
                int nrPozycji =
                    int.Parse(OdbierzDane("Podaj nr. pozycji do usunięcia"));
                zadania.RemoveAt(nrPozycji-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błędne dane!\n{ex.Message}");
            }
        }
    }
}
