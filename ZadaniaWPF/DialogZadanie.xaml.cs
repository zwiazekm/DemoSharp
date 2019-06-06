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
using System.Windows.Shapes;
using Szkolenie.ZadaniaLib;

namespace ZadaniaWPF
{
    /// <summary>
    /// Interaction logic for DialogZadanie.xaml
    /// </summary>
    public partial class DialogZadanie : Window
    {
        public DialogZadanie()
        {
            InitializeComponent();
            
        }

        public Zadanie MojeZadanie{ get; set; }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
