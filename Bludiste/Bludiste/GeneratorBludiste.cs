using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bludiste
{
    /// <summary>
    /// Trida generujici bludiste.
    /// </summary>
    public class GeneratorBludiste
    {
        /// <summary>
        /// Povoleni/zakazeni debug rezimu.
        /// </summary>
        private Boolean DBG = true;

        public GeneratorBludiste()
        {
        }

        /// <summary>
        /// V zadanem bludisti proboura stenu mezi sousednimi bunkami.
        /// </summary>
        /// <param name="blud">Bludiste.</param>
        /// <param name="a">Pozice bunky A.</param>
        /// <param name="b">Pozice bunky B.</param>
        private void probourejZed(Bunka[,] blud, Point a, Point b)
        {
            int smera = -1, smerb = -1;
            //bunka a je ve prostred
            //bunka B je nad A
            if (a.Y - 1 == b.Y && a.X == b.X)
            {
                smera = Bunka.NORTH;
                smerb = Bunka.SOUTH;
            }
            //bunka B je vpravo od A
            else if (a.X + 1 == b.X && a.Y == b.Y)
            {
                smera = Bunka.EAST;
                smerb = Bunka.WEST;
            }
            //bunka B je pod A
            else if (a.Y+1 == b.Y && a.X == b.X)
            {
                smera = Bunka.SOUTH;
                smerb = Bunka.NORTH;
            }
            //bunka B je vlevo od A
            else if(a.X-1 == b.X && a.Y == b.Y)
            {
                smera = Bunka.WEST;
                smerb = Bunka.EAST;
            }

            blud[a.X, a.Y].bourejZed(smera);
            blud[b.X, b.Y].bourejZed(smerb);
        }

        /// <summary>
        /// Metoda vygeneruje perfektni bludiste.
        /// </summary>
        /// <param name="w">Sirka bludiste v bunkach.</param>
        /// <param name="h">Vyska bludiste v bunkach.</param>
        /// <returns>Pole bunek reprezentujici bludiste.</returns>
        public Bunka[,] generujPerfektniBludiste(int w, int h)
        {
            int probouraneZdi = 0;

            Bunka[,] bludiste = new Bunka[w,h];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    bludiste[i, j] = new Bunka();
                }
            }

            Stack<Point> zasobnik = new Stack<Point>();

            //vybrani pocatecni bunky
            Random r = new Random();
            Point start = new Point(r.Next(w), r.Next(h));
            zasobnik.Push(start);

            while (zasobnik.Count > 0)
            {
                //pozice bunky v poli bludiste
                Point p = zasobnik.Pop();

                //dokud je cesta, budou se probouravat bunky. Pokud neni cesta, vybere se bunka ze zasobniku.
                Boolean jeCesta = true;

                while (jeCesta)
                {
                    List<Point> nenavstiveno = new List<Point>();
                    //kontrola navstivenosti sousednich bunek
                    //nad bunkou
                    if (p.Y > 0)
                    {
                        if (bludiste[p.X, p.Y - 1].jeNedotcena()) nenavstiveno.Add(new Point(p.X, p.Y - 1));
                    }
                    //vpravo od bunky
                    if (p.X < w-1)
                    {
                        if (bludiste[p.X + 1, p.Y].jeNedotcena()) nenavstiveno.Add(new Point(p.X + 1, p.Y));
                    }
                    //pod bunkou
                    if (p.Y < h-1)
                    {
                        if (bludiste[p.X, p.Y + 1].jeNedotcena()) nenavstiveno.Add(new Point(p.X, p.Y + 1));
                    }
                    //vlevo od bunky
                    if (p.X > 0)
                    {
                        if (bludiste[p.X - 1, p.Y].jeNedotcena()) nenavstiveno.Add(new Point(p.X - 1, p.Y));
                    }

                    //uz neni zadna nenavstivena bunka
                    if (nenavstiveno.Count == 0) jeCesta = false;
                    else
                    {
                        //vyber jedne nenavstivene bunky kudy povede cesta
                        int d = r.Next(nenavstiveno.Count);
                        Point dalsi = nenavstiveno.ElementAt(d);
                        nenavstiveno.RemoveAt(d);
                        probourejZed(bludiste, p, dalsi);
                        probouraneZdi++;

                        //pridani zbylych nenavstivenych bunek do zasobniku
                        for (int i = 0; i < nenavstiveno.Count; i++)
                        {
                            zasobnik.Push(nenavstiveno.ElementAt(i));
                        }

                        //posun do dalsi bunky
                        p = dalsi;
                    }

                }
            }

            dbgOut("Probourano " + probouraneZdi + " zdi");

            return bludiste;
        }

        private void dbgOut(String msg)
        {
            if (DBG)
            {
                Console.WriteLine(DateTime.Now+": "+msg);
            }
        }

    }

}
