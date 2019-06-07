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

namespace WCFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SVCClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientZadania.TaskServiceClient client = 
                new ClientZadania.TaskServiceClient();
            MessageBox.Show(client.Hello("Testus"));
            ClientZadania.Zadanie noweZ = new ClientZadania.Zadanie()
            {
                Tytul = "Remote test",
                Termin = DateTime.Now.AddDays(4)
            };
            MessageBox.Show(client.NoweZadanie(noweZ).ToString());

            ClientZadania.Zadanie z = client.GetZadanie(1);
            MessageBox.Show($"{z.Tytul}, {z.Termin}");

        }
    }
}
