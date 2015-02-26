using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bludiste
{
    public partial class Form1 : Form
    {
        //prommene tykajici se bludiste
        private GeneratorBludiste gb;
        private Bunka[,] bludiste;

        //promenne pro praci s gui
        private Graphics grafika;
        private Bitmap bmp;

        //rozmery jedne bunky bludiste
        private int bunkaX = 15;
        private int bunkaY = 15;

        //odsazeni vykreslovaneho bludiste
        private int offx = 10;
        private int offy = 10;

        //hrace prochazejici bludistem
        private Hrac hrac;

        //pvodni pozice hrace
        private int origX;
        private int origY;

        public Form1()
        {
            InitializeComponent();

            inicBitmapGraf();
            gb = new GeneratorBludiste();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Inicializuje proměnné bmp a grafika.
        /// </summary>
        private void inicBitmapGraf()
        {
            bmp = new Bitmap(krPlocha.Width, krPlocha.Height);
            grafika = Graphics.FromImage(bmp);
            grafika.Clear(Color.White);
        }

        /// <summary>
        /// Zavola metodu, ktera korektne vykresi bmp na vykreslovaci panel.
        /// </summary>
        private void prekresliPanel()
        {
            krPlocha_Paint(this, null);
        }

        /// <summary>
        /// Nacte z editu potrebne hodnoty, zkontroluje je a vygeneruje bludiste zadanych rozmeru.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bGenerujBludiste_Click(object sender, EventArgs e)
        {
            if (tbSirka.Text.Length == 0 || tbVyska.Text.Length == 0)
            {
                return;
            }

            int w = Convert.ToInt32(tbSirka.Text);
            int h = Convert.ToInt32(tbVyska.Text);

            //omezeni rozmeru
            if (w < 0 || h < 0 || w > 500 || h > 500)
            {
                return;
            }

            //generovani bludiste
            this.bludiste = gb.generujPerfektniBludiste(w, h);
            
            Random r = new Random();

            //vygeneruje cilovou bunku
            int cx = r.Next(w);
            int cy = r.Next(h);
            bludiste[cx, cy].cil = true;

            //pozice hrace
            int hx = r.Next(w);
            int hy = r.Next(h);
            while (hx == cx && hy == cy)
            {
                hx = r.Next(w);
                hy = r.Next(h);
            }
            hrac = new Hrac(hx, hy);
            origX = hx;
            origY = hy;

            vykresliBludiste();
            vykresliHrace();

            this.Focus();
        }

        private void cleanPanel()
        {
            grafika.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, krPlocha.Width, krPlocha.Height));
            prekresliPanel();
        }

        private void vykresliHrace()
        {
            if (this.hrac == null) return;
            int hw = bunkaX - 2;
            int hh = bunkaY - 2;

            //smazani stare pozice hrace
            grafika.FillEllipse(new SolidBrush(Color.White), offx + hrac.Xold * bunkaX + 1, offy + hrac.Yold * bunkaY + 1, hw, hh);
            grafika.DrawEllipse(new Pen(Color.White), offx + hrac.Xold * bunkaX + 1, offy + hrac.Yold * bunkaY + 1, hw, hh);

            //nova pozice
            grafika.FillEllipse(new SolidBrush(Color.Red), offx + hrac.X * bunkaX + 1, offy + hrac.Y * bunkaY + 1, hw, hh);
            grafika.DrawEllipse(new Pen(Color.Black), offx + hrac.X * bunkaX + 1, offy + hrac.Y * bunkaY + 1, hw, hh);
            prekresliPanel();
        }

        /// <summary>
        /// Metoda vykresli bludiste na vykreslovaci panel.
        /// </summary>
        private void vykresliBludiste()
        {
            krPlocha.Width = offx * 2 + bludiste.GetLength(0) * bunkaX+1;
            krPlocha.Height = offy * 2 + bludiste.GetLength(1) * bunkaY+1;
            inicBitmapGraf();

            //MessageBox.Show("Pozice panelu: [" + krPlocha.Location.X + "," + krPlocha.Location.Y + "]"+
            //                 "Rozmery panelu: ["+krPlocha.Width+","+krPlocha.Height+"]");
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < bludiste.GetLength(0); i++)
            {
                for (int j = 0; j < bludiste.GetLength(1); j++)
                {
                    if (bludiste[i, j].zed[Bunka.NORTH])
                    {
                        grafika.DrawLine(pen, new Point(offx + i * bunkaX, offy + j * bunkaY),
                            new Point(offx + (i + 1) * bunkaX, offy + j * bunkaY));
                    }

                    if (bludiste[i, j].zed[Bunka.EAST])
                    {
                        grafika.DrawLine(pen, new Point(offx + (i + 1) * bunkaX, offy + j * bunkaY),
                            new Point(offx + (i + 1) * bunkaX, offy + (j + 1) * bunkaY));
                    }

                    if (bludiste[i, j].zed[Bunka.SOUTH])
                    {
                        grafika.DrawLine(pen, new Point(offx + i * bunkaX, offy + (j + 1) * bunkaY), 
                            new Point(offx + (i + 1) * bunkaX, offy + (j + 1) * bunkaY));
                    }

                    if (bludiste[i, j].zed[Bunka.WEST])
                    {
                        grafika.DrawLine(pen, new Point(offx + i * bunkaX, offy + j * bunkaY),
                            new Point(offx + i * bunkaX, offy + (j + 1) * bunkaY));
                    }

                    //vykresleni cile
                    if (bludiste[i,j].cil)
                    {
                        grafika.FillEllipse(new SolidBrush(Color.Yellow), offx + i * bunkaX, offy + j * bunkaY, bunkaX, bunkaY);
                        grafika.DrawEllipse(new Pen(Color.Green), offx + i * bunkaX, offy + j * bunkaY, bunkaX, bunkaY);
                        float sx = offx + i * bunkaX + bunkaX / 7f; 
                        float sy = offy + j * bunkaY + bunkaY / 7f;
                        grafika.DrawString("C", new Font("SansSerif", 8), new SolidBrush(Color.Black), new PointF(sx,sy));
                    }
                }
            }

            prekresliPanel();
        }

        /// <summary>
        /// Vykresluji bmp na vykreslovaci plochu, stara se tak o prekreslovani panelu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void krPlocha_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null) return;

            Graphics grp = krPlocha.CreateGraphics();
            int whiteSpLeft = 0;
            int whiteSpTop = 0;
            double aspecRatioSrc = (double)bmp.Width / bmp.Height;
            double aspecRatioDst = (double)krPlocha.Width / krPlocha.Height;

            if(aspecRatioSrc > aspecRatioDst)
            {
                whiteSpTop = krPlocha.Height - (int)(krPlocha.Width / aspecRatioSrc);
                whiteSpTop >>= 1;
            }
            else
            {
                whiteSpLeft = krPlocha.Width - (int)(krPlocha.Height * aspecRatioSrc);
                whiteSpLeft >>= 1;
            }

            Rectangle rSource = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Rectangle rDest = new Rectangle(whiteSpLeft, whiteSpTop, krPlocha.Width - (whiteSpLeft << 1), krPlocha.Height - (whiteSpTop << 1));

            grp.DrawImage(bmp, rDest, rSource, GraphicsUnit.Pixel);
            grp.Dispose();
        }

        private void pohybHrace(object sender, KeyPressEventArgs e)
        {
            if(this.hrac == null) return;
            if (bludiste[hrac.X, hrac.Y].cil) return;
            switch (e.KeyChar)
            {
                case 'w':
                case 'W':
                    {
                        if (hrac.Y > 0 && !bludiste[hrac.X,hrac.Y].zed[Bunka.NORTH])
                        {
                            hrac.Y = hrac.Y - 1;
                            hrac.pocetKroku++;
                        }
                    }break;

                case 's':
                case 'S':
                    {
                        if (hrac.Y < bludiste.GetLength(1) - 1 && !bludiste[hrac.X, hrac.Y].zed[Bunka.SOUTH])
                        {
                            hrac.Y = hrac.Y + 1;
                            hrac.pocetKroku++;
                        }
                    }break;

                case 'a':
                case 'A':
                    {
                        if (hrac.X > 0 && !bludiste[hrac.X, hrac.Y].zed[Bunka.WEST])
                        {
                            hrac.X = hrac.X - 1;
                            hrac.pocetKroku++;
                        }
                    }break;
                
                case 'd':
                case 'D':
                    {
                        if (hrac.X < bludiste.GetLength(0) - 1 && !bludiste[hrac.X, hrac.Y].zed[Bunka.EAST])
                        {
                            hrac.X = hrac.X + 1;
                            hrac.pocetKroku++;
                        }
                    }break;
            }

            vykresliHrace();

            //je v cili?
            if (bludiste[hrac.X, hrac.Y].cil)
            {
                MessageBox.Show("Cíl! Hráč prošel bludištěm za " + hrac.pocetKroku + " kroků.");
                scoreBoard.AppendText("Cíle dosaženo po " + hrac.pocetKroku + " krocích.\r\n");

            }
        }

        private void resetBludiste(object sender, EventArgs e)
        {
            hrac = new Hrac(origX, origY);
            vykresliBludiste();
            vykresliHrace();
        }
    }
}
