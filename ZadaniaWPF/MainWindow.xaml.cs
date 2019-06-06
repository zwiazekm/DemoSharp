using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Szkolenie.ZadaniaLib;
using System.IO;
using System.Configuration;
using Microsoft.Win32;
using System.Xml.Linq;

namespace ZadaniaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrganizerZadan zadania = new OrganizerZadan();
        string localPath = ConfigurationManager.AppSettings["myPath"];

        public MainWindow()
        {
            InitializeComponent();
            KontrolaFolderu();
        }

        public void KontrolaFolderu()
        {
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }

        }

        private void NoweZadanie_Click(object sender, RoutedEventArgs e)
        {
            DialogZadanie dialog = new DialogZadanie();
            dialog.Title = "Nowe zadanie";
            //Otwrcie okna
            if (dialog.ShowDialog().Value)
            {
                var tytul = dialog.tytulText.Text;
                DateTime termin = (dialog.terminDatePicker.SelectedDate.HasValue) ?
                    dialog.terminDatePicker.SelectedDate.Value : DateTime.Today;
                zadania.DodajZadanie(tytul, termin);
                ZadaniGrid.ItemsSource = zadania.ListaZadan();
                MessageBox.Show("Zadanie dodane", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show(zadania.ListaZadan().ToList().Count().ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ZadaniGrid.ItemsSource = zadania.ListaZadan();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            string plikZadan = "listazadan.txt";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".txt";
            saveDialog.Filter = "Pliki tekstowe .txt | *.txt";
            saveDialog.FileName = $"{localPath}{plikZadan}";

            if (saveDialog.ShowDialog().Value)
            {
                var lista = zadania.ZadaniaNieZakonczone();
                File.WriteAllLines(saveDialog.FileName, lista);
                MessageBox.Show("Zapisane");
            }
        }

        private void StreamButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = localPath + "listazadan.txt";
            FileStream file = new FileStream(filePath, FileMode.Open);
            BinaryReader br = new BinaryReader(file);
            byte[] dane = new byte[br.BaseStream.Length];
            int pozycja = 0;
            int retByte;
            while ((retByte=br.Read())!=-1)
            {
                dane[pozycja] = (byte)retByte;
                pozycja += sizeof(byte);
            }
            br.Close();
            file.Close();
            string wynik = "";
            foreach (var item in dane)
            {
                wynik += item;
            }
            MessageBox.Show(wynik);
            file = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(file);
            StringBuilder sb = new StringBuilder();
            while (sr.Peek() != -1)
            {
                sb.AppendLine(sr.ReadLine());
            }
            sr.Close();
            file.Close();

            MessageBox.Show(sb.ToString());

        }

        private void LoadXml_Click(object sender, RoutedEventArgs e)
        {
            string file = localPath + "xmlzadanie.xml";
            XDocument xdoc = XDocument.Load(file);
            var wynik = from el in xdoc.Root.Elements()
                        where el.Name == "zadanie"
                        select el.Attribute("id").Value;
            string info = "";
            foreach (var item in wynik)
            {
                info += item;
            }
            MessageBox.Show(info);            
        }
    }
}
