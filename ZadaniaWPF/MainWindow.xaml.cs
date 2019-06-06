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

namespace ZadaniaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrganizerZadan zadania = new OrganizerZadan();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NoweZadanie_Click(object sender, RoutedEventArgs e)
        {
            DialogZadanie dialog = new DialogZadanie();
            dialog.Title = "Nowe zadanie";
            //Otwrcie okna
            if (dialog.ShowDialog().Value)
            {
                MessageBox.Show("Zadanie dodane", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
