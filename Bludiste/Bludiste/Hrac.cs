using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bludiste
{
    /// <summary>
    /// Trida implementuje hrace prochazejiciho bludistem.
    /// </summary>
    class Hrac
    {
        //pozice hrace, pri vykresleni nutno prenasobit meritkem
        private int Xpoz;
        private int Ypoz;

        public int Xold;
        public int Yold;

        //pocet kroku bludistem
        public int pocetKroku;

        /// <summary>
        /// Konstruktor hrace. 
        /// </summary>
        /// <param name="x">Vychozi pozice X.</param>
        /// <param name="y">Vychozi pozice Y.</param>
        public Hrac(int x, int y)
        {
            this.Xpoz = x;
            this.Ypoz = y;
            this.Xold = x;
            this.Yold = y;
            this.pocetKroku = 0;
        }


        public int X
        {
            set
            {
                this.Xold = Xpoz;
                this.Yold = Ypoz;
                this.Xpoz = value;
            }

            get 
            {
                return Xpoz;
            }
        }

        public int Y
        {
            set
            {
                this.Xold = Xpoz;
                this.Yold = Ypoz;
                this.Ypoz = value;
            }

            get
            {
                return Ypoz;
            }
        }

        public String toString()
        {
            return "poz: ["+X+","+Y+"] \r\nold: ["+Xold+","+Yold+"] \r\n";
        }
    }
}
