using System;
using System.Reflection.Metadata;
using Windows.Graphics.Printing.PrintSupport;
//using Accessibility;

namespace Chess
{
	public class Table 
	{
        int[,] tab2 = new int[8, 8];
        public int[,] tab = new int[8, 8];
        //PictureBox[,] tabpics = new PictureBox[8, 8];
        Bitmap[] pics = new Bitmap[40];
        Bitmap bm ;
        int x = 80, y = 80, ii = -1, jj = -1, xx = 0, yy = 0, pic = 0;
        public Form1 form;
        public int refr=0, fois=0,tour=0;
        System.Random r = new System.Random();
        struct Depl
        {
            public int a, b, c, d,pc1,pc2,ind;
        }
        Depl dp = new Depl();
        List<Depl> depls = new List<Depl>();
        int ind = -1;
        public Table(Form1 ff,int wd)
		{
            form = ff;
            x = wd;
            y = wd;
		}


        public int Solcalcul16(int tr, int pr, ref int i0, ref int j0, ref int i1, ref int j1, ref int nb)
        {
            Thcorps[] th = new Thcorps[16];
            int i = 0;
            for (i = 0; i < 16; i++)
            {
                th[i] = new Thcorps();
                th[i].Init16(i, tr, pr, tab);
            }
            for (i = 0; i < 16; i++)
            {
                th[i].thr.Start();
            }

            int som = 0;
            while (som < 16)
            {
                som = 0;
                Thread.Sleep(20);
                for (i = 0; i < 16; i++) som += th[i].st;

            }
            nb = 0;
            
            for (i = 0; i < 16; i++) nb += th[i].nb;
            if (nb > 0)
            {
                i = 0;
                int cn = 0;
                int mx = 0;
                while (i < 16)
                {
                    if (i == 0)
                    {
                        mx = th[i].mmx;
                        i0 = th[i].ti;
                        j0 = th[i].tj;
                        i1 = th[i].tk;
                        j1 = th[i].tl;
                        cn = 1;
                    }
                    else if (th[i].mmx > mx)
                    {
                        mx = th[i].mmx;
                        i0 = th[i].ti;
                        j0 = th[i].tj;
                        i1 = th[i].tk;
                        j1 = th[i].tl;
                        cn = 1;
                    }
                    else if (th[i].mmx == mx)
                    {
                        cn++;
                        Random r = new Random();
                        int rdm = r.Next(cn);
                        if (rdm == 1)
                        {
                            mx = th[i].mmx;
                            i0 = th[i].ti;
                            j0 = th[i].tj;
                            i1 = th[i].tk;
                            j1 = th[i].tl;


                        }
                    }
                    i++;

                }
                return mx;
            }
            else {
                
                i0 = -1;
                j0 = -1;
                i1 = -1;
                j1 = -1;
                return -5000;
            }
        }


        public int Solcalcul8(int tr, int pr, ref int i0, ref int j0, ref int i1, ref int j1)
        {
            Thcorps[] th = new Thcorps[8];
            int i = 0;
            for (i = 0; i < 8; i++)
            {
                th[i] = new Thcorps();
                th[i].Init8(i, tr, pr, tab);
            }
            for (i = 0; i < 8; i++)
            {
                th[i].thr.Start();
            }

            int som = 0;
            while (som < 8)
            {
                som = 0;
                Thread.Sleep(20);
                for (i = 0; i < 8; i++) som += th[i].st;

            }
            
            i = 0;
            int mx = 0 ,cn = 0;
            while (i < 8)
            {
                if (i == 0)
                {
                    mx = th[i].mmx;
                    i0 = th[i].ti;
                    j0 = th[i].tj;
                    i1 = th[i].tk;
                    j1 = th[i].tl;
                    cn = 1;
                }
                else if (th[i].mmx > mx)
                {
                    mx = th[i].mmx;
                    i0 = th[i].ti;
                    j0 = th[i].tj;
                    i1 = th[i].tk;
                    j1 = th[i].tl;
                    cn = 1;
                }
                else if (th[i].mmx == mx)
                {
                    cn++;
                    Random r = new Random();
                    int rdm = r.Next(cn);
                    if (rdm == 1)
                    {
                        mx = th[i].mmx;
                        i0 = th[i].ti;
                        j0 = th[i].tj;
                        i1 = th[i].tk;
                        j1 = th[i].tl;


                    }
                }
                i++;

            }
            return mx;
        }



        public int Pointp(int piec)
        {
            if ((piec == 1) || (piec == 8) || (piec == 25) || (piec == 32)) return 5;
            else if ((piec == 2) || (piec == 7) || (piec == 26) || (piec == 31)) return 4;
            else if ((piec == 3) || (piec == 6) || (piec == 27) || (piec == 30)) return 4;
            else if ((piec == 4) || (piec == 28)) return 15;
            else if ((piec == 5) || (piec == 29)) return 80;
            else if ((piec > 8) && (piec < 25)) return 1;
            else return 0;


        }
        public int Solcalcul(int tr, int pr, ref int i0, ref int j0, ref int i1, ref int j1)
        {
            int mx = -1000, p ,pt, a=0, b = 0, c = 0, d = 0;

            int i , j , k , l ,cn=0;

            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (((tr == 0) && (tab[i, j] <= 16) && (tab[i,j]>0)) || ((tr == 1) && (tab[i, j] >= 17)))
                    {
                        for (k = 0; k < 8; k++)
                            for (l = 0; l < 8; l++)
                            {
                                if (Verify(i, j, k, l))
                                {
                                    p = tab[k, l];
                                    pt = Pointp(p);
                                    
                                    tab[k, l] = tab[i, j];
                                    tab[i, j] = 0;
                                    if ((p != 5) && (p != 29)){

                                        if (pr > 1) pt = pt - Solcalcul(1 - tr, pr - 1, ref a, ref b, ref c, ref d);
                                    }
                                    if (pt > mx)
                                    {
                                        mx = pt;
                                        i0 = i;
                                        j0 = j;
                                        i1 = k;
                                        j1 = l;
                                        cn = 1;
                                    }
                                    else if (pt == mx)
                                    {
                                        cn++;
                                        int rdm = r.Next(cn );
                                        if (rdm == 1)
                                        {
                                            mx = pt;
                                            i0 = i;
                                            j0 = j;
                                            i1 = k;
                                            j1 = l;
                                           

                                        }
                                    }
                                    tab[i, j] = tab[k,l];
                                    tab[k, l] = p;

                                }


                            }
                    }




                }
            if (mx == -1000)
            {
                mx = 0;
                i0 = 0;
                i1 = 0;
                j0 = 0;
                j1 = 0;
            }
            return mx;
        }
        private void Showcase(int i, int j, int p)
        {


            //Point l = new Point(50 + x * i, 50 + j * y);
            int cl = 0;
            if ((i + j) % 2 == 0) cl = 33;
            form.CreateGraphics().DrawImage(pics[cl], 50 + x * i, 50 + y * j, x, y);
            if ((p > 0)&&((i!=ii)||(j!=jj)) )form.CreateGraphics().DrawImage(pics[p], 50 + x * i, 50 + y * j, x, y);

        }
        public void deplacer(int i0,int j0,int i1,int j1)
        {
            if (tab[i0, j0] != 0)
            {
                int x1 = 50 + x * i0, y1 = 50 + y * j0;
                int x2 = 50 + x * i1, y2 = 50 + y * j1;
                int px = (x2 - x1) / 10,py=(y2-y1)/10;
                int i,p=tab[i0,j0];
                for (i = 0; i < 10; i++)
                {
                    form.CreateGraphics().DrawImage(pics[p], x1 + px * i, y1 + py * i, x, y);
                    Thread.Sleep(100);
                }
                dp.a = i0;
                dp.b = j0;
                dp.c = i1;
                dp.d = j1;
                dp.pc1 = p;
                dp.pc2 = tab[i1, j1];
                i = depls.Count-1;
                while (i >ind)
                {
                    depls.RemoveAt(i);
                    i--;
                }
                depls.Add(dp);
                ind = depls.Count-1;
                tab[i0, j0] = 0;
                tab[i1, j1] = p;
            }
            Refreshtab();

        }
        public void Retour()
        {
            if (ind >= 0)
            {
                //
                dp = depls[ind];
                int i1 = dp.a, j1 = dp.b, i0 = dp.c, j0 = dp.d, pc1 = dp.pc1, pc2 = dp.pc2;
                if (tab[i0, j0] != 0)
                {
                    int x1 = 50 + x * i0, y1 = 50 + y * j0;
                    int x2 = 50 + x * i1, y2 = 50 + y * j1;
                    int px = (x2 - x1) / 10, py = (y2 - y1) / 10;
                    int i, p = tab[i0, j0];
                    for (i = 0; i < 10; i++)
                    {
                        form.CreateGraphics().DrawImage(pics[pc1], x1 + px * i, y1 + py * i, x, y);
                        Thread.Sleep(100);
                    }

                    tab[i0, j0] = pc2;
                    tab[i1, j1] = pc1;
                    ind--;
                    //depls.Remove(d);
                }
                Refreshtab();
                form.label1.Text = "En recul!";
            }
            else form.label1.Text = "Aucune autre valeur de retour enregistrée!";
        }
        public void Avance()
        {
            if (ind <depls.Count-1)
            {
                ind++;
                dp = depls[ind];
                int i0 = dp.a, j0 = dp.b, i1 = dp.c, j1 = dp.d, pc1 = dp.pc1, pc2 = dp.pc2;
                if (tab[i0, j0] != 0)
                {
                    int x1 = 50 + x * i0, y1 = 50 + y * j0;
                    int x2 = 50 + x * i1, y2 = 50 + y * j1;
                    int px = (x2 - x1) / 10, py = (y2 - y1) / 10;
                    int i, p = tab[i0, j0];
                    for (i = 0; i < 10; i++)
                    {
                        form.CreateGraphics().DrawImage(pics[pc1], x1 + px * i, y1 + py * i, x, y);
                        Thread.Sleep(100);
                    }

                    tab[i0, j0] = 0;
                    tab[i1, j1] = pc1;
                    //if(ind<= depls.Count-2) ind++;
                    //depls.Remove(d);
                }
                Refreshtab();
                form.label1.Text = "En avant!";
            }
            else form.label1.Text = "Aucune autre valeur de plus enregistrée!";
        }
       

        public void Refreshtab()
        {

            int i, j;

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    Showcase(i, j, tab[i, j]);


                }
            }
            refr = 0;
            fois++;
          
        }
        public void Init()
        {
            int i, j;

            for (i = 0; i < 34; i++)

            {
                switch (i)
                {
                    case 0: { pics[i] = new Bitmap("piece/vide7.jpg"); break; }
                    case 1: { pics[i] = new Bitmap("piece/tn.png"); break; }
                    case 2: { pics[i] = new Bitmap("piece/chn7.png"); break; }
                    case 3: { pics[i] = new Bitmap("piece/fn7.png"); break; }
                    case 4: { pics[i] = new Bitmap("piece/reinn2.png"); break; }
                    case 5: { pics[i] = new Bitmap("piece/rn6.png"); break; }
                    case 6: { pics[i] = new Bitmap("piece/fn7.png"); break; }
                    case 7: { pics[i] = new Bitmap("piece/chn7.png"); break; }
                    case 8: { pics[i] = new Bitmap("piece/tn.png"); break; }
                    case 9: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 10: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 11: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 12: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 13: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 14: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 15: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 16: { pics[i] = new Bitmap("piece/pn.png"); break; }
                    case 17: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 18: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 19: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 20: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 21: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 22: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 23: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 24: { pics[i] = new Bitmap("piece/pb.png"); break; }
                    case 25: { pics[i] = new Bitmap("piece/tb.png"); break; }
                    case 26: { pics[i] = new Bitmap("piece/chb.png"); break; }
                    case 27: { pics[i] = new Bitmap("piece/fb8.png"); break; }
                    case 28: { pics[i] = new Bitmap("piece/reinb3.png"); break; }
                    case 29: { pics[i] = new Bitmap("piece/rb4.png"); break; }
                    case 30: { pics[i] = new Bitmap("piece/fb8.png"); break; }
                    case 31: { pics[i] = new Bitmap("piece/chb.png"); break; }
                    case 32: { pics[i] = new Bitmap("piece/tb.png"); break; }
                    case 33: { pics[i] = new Bitmap("piece/vide8.jpg"); break; }



                    default: { pics[i] = new Bitmap("piece/vide6.jpg"); break; }
                }



            }
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    tab[i, j] = 0;
                    //tabpic[i,j] = null;
                }
            }
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    tab[i, j] = 1 + i + j * 8;

                }
            }
            for (i = 0; i < 8; i++)
            {
                for (j = 6; j < 8; j++)
                {
                    tab[i, j] = 1 + i + (j - 4) * 8;
                }
            }

            ind = -1;
            depls.Clear();
        }
        

        public void Form1_MouseDown( MouseEventArgs e)
        {
            int maxx = 50 + x * 8;
            int maxy = 50 + y * 8;
            //label1.Text = e.X.ToString();



            if ((e.X > 50) && (e.X < maxx) && (e.Y > 50) && (e.Y < maxy))
            {
                ii = (e.X - 50) / x;
                jj = (e.Y - 50) / y;
                bm = pics[tab[ii, jj]];

                xx = e.X;
                yy = e.Y;
                pic = tab[ii, jj];
                //tab[ii, jj] = 0;

                Showcase(ii, jj, 0);
                if (pic != 0)
                {
                    int x2 = e.X - x / 2, y2 = e.Y - y / 2;

                    if (x2 < 50) x2 = 50;
                    else if (x2 > maxx - x) x2 = maxx - x;
                    if (y2 < 50) y2 = 50;
                    else if (y2 > maxy - y) y2 = maxy - y;

                    form.CreateGraphics().DrawImage(bm, x2, y2, x, y);
                }
            }
        }

        public void Form1_MouseMove(MouseEventArgs e)
        {
            if (pic != 0)
            {
                /*int cl = (ii + jj) % 2;
                if (cl == 0) this.CreateGraphics().DrawImage(pics[33], 50 + ii * x, 50 + jj * y, x, y);
                else this.CreateGraphics().DrawImage(pics[0], 50 + ii * x, 50 + jj * y, x, y);*/
                int maxx = 50 + x * 8;
                int maxy = 50 + y * 8;
                //label1.Text = e.X.ToString();

               // int i2 = (e.X - 50) / x, j2 = (e.Y - 50) / y;

                int x2 = e.X - x / 2, y2 = e.Y - y / 2;

                if (x2 < 50) x2 = 50;
                else if (x2 > maxx - x) x2 = maxx - x;
                if (y2 < 50) y2 = 50;
                else if (y2 > maxy - y) y2 = maxy - y;

                int x3 = x2 + x / 2, y3 = y2 + y / 2;



                int i3 = (xx - 50) / x, j3 = (yy - 50) / y;

                //int i4 = (x3 - 50) / x, j4 = (y3 - 50) / y;


                Showcase(i3, j3, tab[i3, j3]);

                int x4 = x3 - i3 * x - 50, y4 = y3 - j3 * y - 50;

                //label1.Text = x4.ToString() + "  " + y4.ToString();

                if (x4 < x / 2)
                {


                    Showcase(i3 - 1, j3, tab[i3 - 1, j3]);
                }
                else if (x4 > x / 2)
                {


                    Showcase(i3 + 1, j3, tab[i3 + 1, j3]);
                }

                if (y4 < y / 2)
                {


                    Showcase(i3, j3 - 1, tab[i3, j3 - 1]);
                }
                else if (y4 > y / 2)
                {


                    Showcase(i3, j3 + 1, tab[i3, j3 + 1]);
                }

                if ((x4 < x / 2) && (y4 < y / 2))
                {


                    Showcase(i3 - 1, j3 - 1, tab[i3 - 1, j3 - 1]);
                }
                else if ((x4 < x / 2) && (y4 > y / 2))
                {


                    Showcase(i3 - 1, j3 + 1, tab[i3 - 1, j3 + 1]);
                }
                else if ((x4 > x / 2) && (y4 > y / 2))
                {
                    Showcase(i3 + 1, j3 + 1, tab[i3 + 1, j3 + 1]);
                }
                else if ((x4 > x / 2) && (y4 < y / 2))
                {
                    Showcase(i3 + 1, j3 - 1, tab[i3 + 1, j3 - 1]);
                }

                form.CreateGraphics().DrawImage(bm, x2, y2, x, y);
                xx = x3;
                yy = y3;






            }
        }

        public void Form1_MouseUp( MouseEventArgs e)
        {
            if (pic != 0)
            {
                int maxx = 50 + x * 8;
                int maxy = 50 + y * 8;




                if ((e.X > 50) && (e.X < maxx) && (e.Y > 50) && (e.Y < maxy))
                {


                    int i2 = (e.X - 50) / x, j2 = (yy - 50) / y;
                    if (Verify(ii,jj,i2,j2))
                    {
                        dp.a = ii;
                        dp.b = jj;
                        dp.c = i2;
                        dp.d = j2;
                        dp.pc1 = pic;
                        dp.pc2 = tab[i2, j2];
                        int i = depls.Count - 1;
                        while (i > ind)
                        {
                            depls.RemoveAt(i);
                            i--;
                        }
                        depls.Add(dp);
                        ind = depls.Count - 1;

                        tab[i2, j2] = pic;
                        form.label1.Text ="piece "+pic.ToString()+" "+ ii.ToString()+" "+jj.ToString()+"-"+i2.ToString()+" "+j2.ToString(); ;
                        //bm = null;
                        pic = 0;
                        tab[ii, jj] = 0;
                        ii = -1;
                        jj = -1;
                    }
                    
                    else
                    {
                        //i2 = ii;j2 = jj;
                        ii = -1;jj = -1;
                        
                        //bm.
                        pic = 0;
                    }
                }
                else
                {
                    //int i2 = ii, j2 = jj;
                    ii = -1; jj = -1;
                    
                    //bm.
                    pic = 0;

                }
                
                Refreshtab();
            }
        }
        private bool Vide2(int i0, int j0, int i1, int j1)
        {
            bool b ;
            if (Math.Abs(i0 - i1) != Math.Abs(j0 - j1)) return false;
            else if ((i0 - i1) == (j0 - j1))
            {
                int i3 = i0, j3 = j0, i4 = i1;
                

                if (i0 > i1) { i3 = i1; j3 = j1; i4 = i0;  }
                i3++;j3++;

                b = true;
                while (i3 < i4)
                {
                    if (tab[i3, j3] != 0) b = false;

                    i3++;
                    j3++;
                }
                return b;


            }
            else if ((i0 - i1) == (j1 - j0))
            {
                int i3 = i0, j3 = j0, i4 = i1;
                if (i0 > i1) { i3 = i1; j3 = j1; i4 = i0;  }
                i3++;j3--;

                b = true;
                while (i3 < i4)
                {
                    if (tab[i3, j3] != 0) b = false;

                    i3++;
                    j3--;
                }
                return b;


            }
            else return false;

        }
        private bool Vide1(int i0,int j0,int i1,int j1)
        {
            bool b ;
            if (i0 == i1)
            {
                if (Math.Abs(j0 - j1) < 2) return true;
                else
                {
                    int j,j3=j0,j4=j1;
                    if (j3 > j4) { j3 = j1;j4 = j0; }
                    b = true;
                    for (j = j3 + 1; j < j4; j++)
                    {
                        if (tab[i0, j] != 0) b = false;
                    }
                    return b;
                }
            }
            else if (j0 == j1)
            {
                if (Math.Abs(i0 - i1) < 2) return true;
                else
                {
                    int i , i3 = i0, i4 = i1; ;
                    if (i3 > i4) { i3 = i1; i4 = i0; }
                    b = true;
                    for (i = i3 + 1; i < i4; i++)
                    {
                        if (tab[i, j0] != 0) b = false;
                    }
                    return b;
                }
            }
            else return false;
        }

        private bool Verifyl(int i0,int j0,int i1, int j1)
        {
            
            if ((Math.Abs(i0 - i1) == 1) && (Math.Abs(j0 - j1) == 2)) return true;
            else if ((Math.Abs(i0 - i1) == 2) && (Math.Abs(j0 - j1) == 1)) return true;
            return false;

        }
        public bool Verify(int i0,int j0,int i1,int j1)
        {
            int pp = tab[i0, j0];
            if ((pp == 1) || (pp == 8) || (pp == 25) || (pp == 32))
            {
                if (Vide1(i0, j0, i1, j1))
                {
                    double f = 2.5 * (pp - 16.5) * (tab[i1, j1] - 16.5);
                    if (tab[i1, j1] == 0) return true;
                    else if (f < 0) return true;
                    else return false;

                }

                else return false;

            }
            else if ((pp == 3) || (pp == 6) || (pp == 27) || (pp == 30))
            {
                if (Vide2(i0, j0, i1, j1))
                {
                    double f = 2.5 * (pp - 16.5) * (tab[i1, j1] - 16.5);
                    if (tab[i1, j1] == 0) return true;
                    else if (f < 0) return true;
                    else return false;

                }

                else return false;

            }
            else if ((pp == 2) || (pp == 7) || (pp == 26) || (pp == 31))
            {
                if (Verifyl(i0, j0, i1, j1))
                {
                    double f = 2.5 * (pp - 16.5) * (tab[i1, j1] - 16.5);
                    if (tab[i1, j1] == 0) return true;
                    else if (f < 0) return true;
                    else return false;

                }
                else return false;

            }
            else if ((pp == 4) || (pp == 28))
            {
                if (Vide1(i0, j0, i1, j1))
                {
                    double f = 2.5 * (pp - 16.5) * (tab[i1, j1] - 16.5);
                    if (tab[i1, j1] == 0) return true;
                    else if (f < 0) return true;
                    else return false;

                }
                else if (Vide2(i0, j0, i1, j1))
                {
                    double f = 2.5 * (pp - 16.5) * (tab[i1, j1] - 16.5);
                    if (tab[i1, j1] == 0) return true;
                    else if (f < 0) return true;
                    else return false;

                }
                else return false;

            }
            else if ((pp == 5) || (pp == 29))
            {
                if( (Math.Abs(i0 - i1) +Math.Abs(j0-j1)==1)||((Math.Abs(i0-i1)==1)&&(Math.Abs(j0-j1)==1)))
                {
                    double f = 2.5 * (pp - 16.5) * (tab[i1, j1] - 16.5);
                    if (tab[i1, j1] == 0) return true;
                    else if (f < 0) return true;
                    else return false;
                }
                else return false;
            }
            else if ((pp <= 16) && (pp >= 9))
            {
                if (i0 == i1)
                {
                    if (tab[i1, j1] != 0) return false;
                    else if ((j0 == 1) && (j1 == 3) && (tab[i0,2]==0)) return true;
                    else if ((j0 == j1 - 1)) return true;
                    else return false;
                }
                else if (Math.Abs(i0 - i1) == 1)
                {
                    if ((tab[i1, j1] > 16) && (j0 == j1 - 1)) return true;
                    else return false;
                }
                else return false;
            }
            else if ((pp <= 24) && (pp >= 17))
            {
                if (i0 == i1)
                {
                    if (tab[i1, j1] != 0) return false;
                    else if ((j0 == 6) && (j1 == 4)&&(tab[i0, 5] == 0)) return true;
                    else if ((j0 == j1 + 1)) return true;
                    else return false;
                }
                else if (Math.Abs(i0 - i1) == 1)
                {
                    if ((tab[i1, j1] < 17) && (tab[i1, j1] >0) && (j0 == j1 + 1)) return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }
    }
}
