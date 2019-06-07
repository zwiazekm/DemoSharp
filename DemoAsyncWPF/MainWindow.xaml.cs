using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoAsyncWPF
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

        //Długotrwała metoda
        private void longRun()
        {
            MessageBox.Show("Start");
            Thread.Sleep(10000);
            MessageBox.Show("Koniec");
        }
        private string longRun2()
        {
            MessageBox.Show("Start");
            Thread.Sleep(10000);
            return "Koniec";
        }

        private string longRun3()
        {
            MessageBox.Show("Start");
            Thread.Sleep(5000);

            infoText.Dispatcher.BeginInvoke(new Action(()=> infoText.Text="Pracuje...")); //.Text = "Pracuje....";
            Thread.Sleep(5000);

            return "Koniec";
        }

        private void longRun4(CancellationToken token)
        {
            MessageBox.Show("Start");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                token.ThrowIfCancellationRequested();
            }

            MessageBox.Show("Koniec");
        }

        private async Task<string> longRun5()
        {
            MessageBox.Show("Start lr2");
            Task<string> t1 = Task.Run<string>(longRun2);
            return "Koniec lr2 - " + await t1;
        }
        private void LongRunButton_Click(object sender, RoutedEventArgs e)
        {
            //Task t1 = new Task(new Action(longRun));
            Task t1 = new Task(() => longRun());
            t1.Start();

            //Task t2 = Task.Factory.StartNew(longRun);
            Task t2 = Task.Run(longRun);
        }

        private void WaitButton_Click(object sender, RoutedEventArgs e)
        {
            var t1 = Task.Run(longRun);
            MessageBox.Show("Praca..");
            t1.Wait();
            MessageBox.Show("Po wszystkim");
        }

        private void WatAllButton_Click(object sender, RoutedEventArgs e)
        {
            Task[] tasks = new Task[3]
            {
                Task.Run(longRun),
                Task.Run(longRun),
                Task.Run(longRun)
            };

            Task.WaitAll(tasks);

        }

        private async void TaskRetrunButton_Click(object sender, RoutedEventArgs e)
        {
            
            Task<string> t1 = Task.Run<string>(longRun2);
            infoText.IsEnabled = false;
            infoText.Text = await t1;
            infoText.IsEnabled = true;
        }

        private void DispatcherButton_Click(object sender, RoutedEventArgs e)
        {
            Task<string> t1 =Task.Run<string>(longRun3);
            infoText.Text = t1.Result;

        }

        private void CancelTaskButton_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            var t1 = Task.Run(()=>longRun4(ct), ct);
            cts.Cancel();
            try
            {
                t1.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    if (item is TaskCanceledException)
                        MessageBox.Show("Przerwano");
                    else
                       throw;
                }
            }
        }

        private void PrallelButton_Click(object sender, RoutedEventArgs e)
        {
            Parallel.Invoke(() => longRun(),
                () => longRun(),
                () => longRun4(new CancellationToken()));

            //Pętle równoległe
            int from = 0;
            int to = 5000000;
            double[] wynik = new double[to];
            for (from = 0;  from< to; from++)
            {
                wynik[from] = Math.Sqrt(from); 
            }
            MessageBox.Show("Skończone pierwsze");
            from = 0;
            Parallel.For(from, to, i => wynik[i] = Math.Sqrt(i));
            MessageBox.Show("Szkończone drugie");

            var listStr = new List<string>();
            Parallel.ForEach(listStr, item => { });

            var wynikPlinq = from str in listStr.AsParallel()
                        where str.Length > 5
                        select str;
        }

        private void LockMethod()
        {
            lock(new object())
            {

            }
        }

        private async void AwaitableButton_Click(object sender, RoutedEventArgs e)
        {
            var wynik = await longRun5();
        }
    }
}
