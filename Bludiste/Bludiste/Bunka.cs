using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bludiste
{
    /// <summary>
    /// Trida reprezentujici jednu bunku v bludisti.
    /// Bunka ma zdi, ktere jsou implementovany jako pole prommenych boolean.
    /// </summary>
    public class Bunka
    {
        /// <summary>
        /// Konstanty pro pristup do pole zdi.
        /// </summary>
        public const byte NORTH = 0;
        public const byte EAST = 1;
        public const byte SOUTH = 2;
        public const byte WEST = 3;

        public const byte OTEVRENO = 0;
        public const byte NAVSTIVENO = 1;
        public const byte ZAVRENO = 2;

        /// <summary>
        /// Slouzi pri prohledavacim algoritmu.
        /// </summary>
        public int stav;

        /// <summary>
        /// Indikuje cilovou bunku.
        /// </summary>
        private Boolean jeCil;

        /// <summary>
        /// Zdi kolem bunky.
        /// </summary>
        private Boolean[] zdi;

        /// <summary>
        /// Pocet zdi kolem bunky.
        /// </summary>
        private byte pocetZdi = 4;

        /// <summary>
        /// Pole zdi kolem bunky. True znamená zeď.
        /// </summary>
        public Boolean[] zed
        {
            get
            {
                return zdi;
            }
        }

        public Boolean cil
        {
            set
            {
                jeCil = value;
            }

            get
            {
                return jeCil;
            }
        }

        public Bunka()
        {
            zdi = new Boolean[pocetZdi];
            for (int i = 0; i < pocetZdi; i++)
            {
                zdi[i] = true;
            }
            stav = OTEVRENO;
        }

        /// <summary>
        /// Metoda zboura zed u bunky v zadanem smeru.
        /// </summary>
        /// <param name="smer">Smer. Dobre pouzit jednu z konstant.</param>
        public void bourejZed(int smer)
        {
            if (smer >= 0 && smer < pocetZdi)
            {
                zdi[smer] = false;
            }
        }

        /// <summary>
        /// Pokud ma bunka neprobourane vsechny zdi je nedotcena.
        /// </summary>
        /// <returns>True pokud je bunka nedotcena.</returns>
        public Boolean jeNedotcena()
        {
            Boolean vysl = true;
            for (int i = 0; i < pocetZdi; i++)
            {
                vysl = vysl & zdi[i];
            }

            return vysl;
        }
    }

}
