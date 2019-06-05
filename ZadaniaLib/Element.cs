using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie.ZadaniaLib
{
    public abstract class Element
    {
        protected static int ostatnieId;
        protected int id;
        protected string temat;
        protected bool wykonane;

        public virtual string Temat { get; set; }

        public virtual void Zakoncz()
        {
            wykonane = true;
        }

        public abstract string Info();
    }
}
