using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementyC
{
    class DemoDestructor: IDisposable
    {
        //Konstruktor
        public DemoDestructor()
        {
            Console.WriteLine("Konstrukcja obiektu");
        }

        public int LiczbaSobie { get; set; }

        ~DemoDestructor()
        {
            Dispose();
            Console.WriteLine("Destrukcja obiektu");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("Czyszczenie zasobów");
            GC.ReRegisterForFinalize(this);
        }
    }
}
