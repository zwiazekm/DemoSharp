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
using System.Data.SqlClient;
using System.Data;

namespace DemoDBWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Connection string
        string cnnStr = @"Data Source=(localdb)\MSSQLLocalDB; " +
            "Initial Catalog=Zadania;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdoButton_Click(object sender, RoutedEventArgs e)
        {

            //Obiekt connnection
            SqlConnection sqlCnn = new SqlConnection(cnnStr);
            //Obiekt command
            string cmdSqlTxt = "select * from tblZadania";
            SqlCommand cmdSql = new SqlCommand(cmdSqlTxt, sqlCnn);
            sqlCnn.Open();
            //Wykonanie polecenia sql i odebranie wyniku do reader'a
            SqlDataReader dr = cmdSql.ExecuteReader();
            //Odczyt poszczególnych rekordów
            while (dr.Read())
            {
                string temat = dr["tytul"].ToString();
                DateTime termin = dr.GetDateTime(2);
                AdoListBox.Items.Add($"{temat} - {termin.ToShortDateString()}");
            }
            dr.Close();
            sqlCnn.Close();
            
        }

        private void DsButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCnn = new SqlConnection(cnnStr);
            //Obiekt command
            string cmdSqlTxt = "select * from tblZadania";
            SqlCommand cmdSql = new SqlCommand(cmdSqlTxt, sqlCnn);
            //Dataset
            DataSet ds = new DataSet();
            //DataAdpapter synchronizuje dane z bazą
            SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
            daSql.Fill(ds, "Zadania");

            MessageBox.Show( ds.Tables["Zadania"].Rows[1][1].ToString());

            
        }
    }
}
