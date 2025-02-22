using Chess.Properties;

namespace Chess
{
    public partial class Form1 : Form
    {
        Table tb = null;

        public int i, stop = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {




        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tb = new Table(this, 80);

            tb.Init();
            tb.Refreshtab();
        }





        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (tb != null) tb.refr = 1;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (tb != null) tb.refr = 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if ((tb != null) && (tb.refr == 1)) tb.Refreshtab();
        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tb != null) tb.Form1_MouseDown(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tb != null) tb.Form1_MouseMove(e);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (tb != null) tb.Form1_MouseUp(e);
        }

        private void calculeDeSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null) tb.Refreshtab();
        }

        private void joueur1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0;

                tb.tour = 1;

                max = tb.Solcalcul(tb.tour, 4, ref a, ref b, ref c, ref d);
                cd = tb.tab[a, b];
                label1.Text = a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString() + "  max=" + max.ToString() + " tab[a,b]=" + cd.ToString();
                tb.deplacer(a, b, c, d);
                tb.tour = 0;
            }
        }

        private void joueur2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tb != null)
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0;

                tb.tour = 0;

                max = tb.Solcalcul(tb.tour, 4, ref a, ref b, ref c, ref d);
                cd = tb.tab[a, b];
                label1.Text = a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString() + "  max=" + max.ToString() + " tab[a,b]=" + cd.ToString();
                tb.deplacer(a, b, c, d);
                tb.tour = 1;

            }
        }

        private void jouerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((tb != null))
            {
                tm.Interval = 500;
                tm.Enabled = true;
                stop = 0;
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToByte(e.KeyChar) == 27)
            {
                stop = 1;
                label1.Text = "Canceled!";
            }
            else if (Convert.ToByte(e.KeyChar) == 8)
            {
                //tb.Retour();
                if ((stop == 1) && (tb != null)) tb.Retour();
            }
            else if (Convert.ToByte(e.KeyChar) == 97)
            {
                if ((stop == 1) && (tb != null)) tb.Avance();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((stop == 0) && (tb != null))
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0;


                max = tb.Solcalcul(tb.tour, 4, ref a, ref b, ref c, ref d);
                cd = tb.tab[a, b];
                label1.Text = a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString() + "  max=" + max.ToString() + " tab[a,b]=" + cd.ToString();
                tb.deplacer(a, b, c, d);

                if (tb.Solcalcul(1 - tb.tour, 2, ref a, ref b, ref c, ref d) < -50)
                {
                    if (tb.Solcalcul(tb.tour, 1, ref a, ref b, ref c, ref d) > 50)
                    {
                        stop = 1;
                        label1.Text = "Checkmate!";
                    }
                    else
                    {
                        stop = 1;
                        label1.Text = "Checkmate!";
                    }
                }
                else
                {

                    tm.Interval = 500;
                    tm.Enabled = true;
                    tb.tour = 1 - tb.tour;
                }



            }
        }

        private void joueur2Niveau5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0;

                tb.tour = 0;

                max = tb.Solcalcul8(tb.tour, 5, ref a, ref b, ref c, ref d);
                cd = tb.tab[a, b];
                label1.Text = a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString() + " , et  max=" + max.ToString() + " tab[a,b]=" + cd.ToString();
                tb.deplacer(a, b, c, d);
                tb.tour = 1;

            }
        }

        private void joueur1Niveau5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0;

                tb.tour = 1;

                max = tb.Solcalcul8(tb.tour, 5, ref a, ref b, ref c, ref d);
                cd = tb.tab[a, b];
                label1.Text = a.ToString() + " " + b.ToString() + " ==> " + c.ToString() + " " + d.ToString() + " , et  max=" + max.ToString() + " tab[a,b]=" + cd.ToString();
                tb.deplacer(a, b, c, d);
                tb.tour = 0;


            }
        }

        private void jouerAutomatiquementNIveau5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((tb != null))
            {
                tm2.Interval = 500;
                tm2.Enabled = true;
                stop = 0;
            }
        }

        private void tm2_Tick(object sender, EventArgs e)
        {
            if ((stop == 0) && (tb != null))
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0;


                max = tb.Solcalcul8(tb.tour, 5, ref a, ref b, ref c, ref d);
                cd = tb.tab[a, b];
                label1.Text = a.ToString() + " " + b.ToString() + " ==> " + c.ToString() + " " + d.ToString() + ", et  max=" + max.ToString() + ", tab[a,b]=" + cd.ToString();
                tb.deplacer(a, b, c, d);

                if (tb.Solcalcul(1 - tb.tour, 2, ref a, ref b, ref c, ref d) < -50)
                {
                    if (tb.Solcalcul(tb.tour, 1, ref a, ref b, ref c, ref d) > 50)
                    {
                        stop = 1;
                        label1.Text = "Checkmate!";
                    }
                    else
                    {
                        stop = 1;
                        label1.Text = "Checkmate!";
                    }
                }
                else
                {

                    tm2.Interval = 500;
                    tm2.Enabled = true;
                    tb.tour = 1 - tb.tour;
                }



            }
        }

        private void calculDeSolutionAvec8ThreadsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0, nb = 0;

                tb.tour = 1;

                max = tb.Solcalcul16(tb.tour, 5, ref a, ref b, ref c, ref d, ref nb);
                if (nb > 0)
                {
                    cd = tb.tab[a, b];
                    label1.Text = a.ToString() + " " + b.ToString() + " ==> " + c.ToString() + " " + d.ToString() + ", et  max=" + max.ToString() + ", tab[a,b]=" + cd.ToString();
                    tb.deplacer(a, b, c, d);

                    int choix = tb.Solcalcul(1 - tb.tour, 2, ref a, ref b, ref c, ref d);
                    if (choix < -50)
                    {
                        if (tb.Solcalcul(tb.tour, 1, ref a, ref b, ref c, ref d) > 50)
                        {
                            stop = 1;
                            label1.Text += "\nCheckmate!  " + choix.ToString();
                        }
                        else
                        {
                            stop = 1;
                            label1.Text += "\nCheckmate!  " + choix.ToString();
                        }
                    }
                    else if (choix > 50)
                    {
                        stop = 1;
                        label1.Text += "\nPlayer 2 has win the round!  ";
                    }
                    else
                    {
                        tb.tour = 1 - tb.tour;

                        label1.Text += "\nTrace= " + choix.ToString();
                    }

                }
                else
                {
                    if (tb.tour == 0) label1.Text = "Player 2 has already win the rouynd !!";
                    else if (tb.tour == 1) label1.Text = "Player 1 has already win the rouynd !!";
                }

            }
        }

        private void jouerPourJoueur1Pr5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0, nb = 0;

                tb.tour = 0;

                max = tb.Solcalcul16(tb.tour, 5, ref a, ref b, ref c, ref d, ref nb);
                if (nb > 0)
                {
                    cd = tb.tab[a, b];
                    label1.Text = a.ToString() + " " + b.ToString() + " ==> " + c.ToString() + " " + d.ToString() + ", et  max=" + max.ToString() + ", tab[a,b]=" + cd.ToString();
                    tb.deplacer(a, b, c, d);

                    int choix = tb.Solcalcul(1 - tb.tour, 2, ref a, ref b, ref c, ref d);
                    if (choix < -50)
                    {
                        if (tb.Solcalcul(tb.tour, 1, ref a, ref b, ref c, ref d) > 50)
                        {
                            stop = 1;
                            label1.Text += "\nCheckmate!  ";
                        }
                        else
                        {
                            stop = 1;
                            label1.Text += "\nCheckmate!  ";
                        }
                    }
                    else if (choix > 50)
                    {
                        stop = 1;
                        label1.Text += "\nPlayer 1 has win the round!  ";
                    }
                    else
                    {
                        tb.tour = 1 - tb.tour;

                        // label1.Text += "\nNormal";
                    }

                }
                else
                {
                    if (tb.tour == 0) label1.Text = "Player 2 has already win the rouynd !!";
                    else if (tb.tour == 1) label1.Text = "Player 1 has already win the rouynd !!";
                }

            }
        }

        private void jouerAutomatiquementProfondeur5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((tb != null))
            {
                tm3.Interval = 500;
                tm3.Enabled = true;
                stop = 0;
            }
        }

        private void tm3_Tick(object sender, EventArgs e)
        {
            if ((stop == 0) && (tb != null))
            {
                int max = 0, a = 0, b = 0, c = 0, d = 0, cd = 0, nb = 0;


                max = tb.Solcalcul16(tb.tour, 5, ref a, ref b, ref c, ref d, ref nb);
                if (nb > 0)
                {
                    cd = tb.tab[a, b];
                    label1.Text = a.ToString() + " " + b.ToString() + " ==> " + c.ToString() + " " + d.ToString() + ", et  max=" + max.ToString() + ", tab[a,b]=" + cd.ToString();
                    tb.deplacer(a, b, c, d);

                    int choix = tb.Solcalcul(1 - tb.tour, 2, ref a, ref b, ref c, ref d);
                    if (choix < -50)
                    {
                        if (tb.Solcalcul(tb.tour, 1, ref a, ref b, ref c, ref d) > 50)
                        {
                            stop = 1;
                            label1.Text += "\nCheckmate!  ";
                        }
                        else
                        {
                            stop = 1;
                            label1.Text += "\nCheckmate  "; ;
                        }
                    }
                    else if (choix > 50)
                    {
                        stop = 1;
                        if (tb.tour == 1) label1.Text = "Player 2 has already win the rouynd !!";
                        else if (tb.tour == 0) label1.Text = "Player 1 has already win the rouynd !!";
                    }
                    else
                    {
                        tb.tour = 1 - tb.tour;
                        tm3.Interval = 50;
                        tm3.Enabled = true;
                        label1.Text += "\nTrace= " + choix.ToString();
                    }

                }
                else
                {
                    if (tb.tour == 0) label1.Text = "Player 2 has already win the rouynd !!";
                    else if (tb.tour == 1) label1.Text = "Player 1 has already win the rouynd !!";
                }

            }
        }

        private void retourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null) tb.Retour();
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                sv.ShowDialog();
                label1.Text = sv.FileName;
                FileStream f = System.IO.File.Create(sv.FileName);
                byte[] buf = new byte[65];
                for (int i = 0; i < 64; i++)
                {
                    int a = i % 8, b = i / 8; ;
                    buf[i] = Convert.ToByte(tb.tab[a, b]);
                }
                buf[64] = Convert.ToByte(tb.tour);
                f.Write(buf, 0, 65);


                f.Close();
            }
        }

        private void sv_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {


        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            opf.ShowDialog();
            //label1.Text = sv.FileName;
            FileStream f = System.IO.File.OpenRead(opf.FileName);
            byte[] buf = new byte[65];
            f.Read(buf, 0, 65);
            tb = new Table(this, 80);
            tb.Init();
            for (int i = 0; i < 64; i++)
            {
                int a = i % 8, b = i / 8; ;
                tb.tab[a, b] = Convert.ToInt32(buf[i]);
            }
            tb.tour = Convert.ToInt32(buf[64]);
            f.Close();
            tb.Refreshtab();


        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // if ((tb != null) ) tb.Refreshtab();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (tb != null) tb.refr = 1;
        }

        private void redoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((stop == 1) && (tb != null)) tb.Avance();
        }
    }
}
