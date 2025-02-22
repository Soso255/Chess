using Chess;
using System;

public class Thcorps
{
    private int[,] tab = new int[8, 8];
    private int[,] tab2 = new int[33,2];
    //PictureBox[,] tabpics = new PictureBox[8, 8];
    
    
    
    public Thread thr ;
    public int ind = 0, a,b,c,d,ti,tj,tk,tl,mmx;
    public int refr = 0, fois = 0, tour = 0,pr=5,st=0,nb=0;
    System.Random r = new System.Random();

    public Thcorps()
	{
        
	}
    public void Init8(int indice,int tr,int pro, int[,] tabl) 
    { 
        this.ind = indice;
        for(int i=0;i<8;i++)
            for(int j = 0; j < 8; j++)
            {
                this.tab[i, j] = tabl[i, j];
                
            }
        this.pr = pro;
        this.thr = new Thread(new ThreadStart(Solcalcul2));
        this.st = 0;
        this.tour = tr;
    }
    public void Init16(int indice, int tr, int pro, int[,] tabl)
    {
        this.ind = indice;
        for(int i = 0; i < 33; i++)
        {
            tab2[i, 0] = 9;
            tab2[i, 1] = 9;
        }
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
            {
                this.tab[i, j] = tabl[i, j];
                if (tabl[i, j] > 0)
                {
                    this.tab2[tabl[i, j], 0] = i;
                    this.tab2[tabl[i, j], 1] = j;
                }
            }
        
        this.pr = pro;
        this.thr = new Thread(new ThreadStart(Solcalcul3));
        this.st = 0;
        this.tour = tr;
    }
    
    public void Solcalcul3()
    {
        //tab = tab2;
        mmx = -5000;
        int p, pt, a = 0, b = 0, c = 0, d = 0,ne=0;

        int i,j, k, l, cn = 0;
        nb = 0;
        int piec = 1+ind + tour * 16;

        if ((tab2[piec, 0] >= 0) && (tab2[piec, 1] >= 0)&&(tab2[piec, 0] <=8) && (tab2[piec, 1] <=8))
        {
            i = tab2[piec, 0];
            j = tab2[piec, 1];

            for (k = 0; k < 8; k++)
                for (l = 0; l < 8; l++)
                {
                    
                    if (Verify(i, j, k, l))
                    {
                        p = tab[k, l];
                        pt = Pointp(p);

                        tab[k, l] = tab[i,j];
                        tab[i, j] = 0;

                        if ((p != 5) && (p != 29))
                        {
                            if (pr > 1) pt = pt - Solcalcul(1 - this.tour, pr - 1, ref a, ref b, ref c, ref d, ref ne);
                        }
                        if (nb == 0)
                        {
                            mmx = pt;
                            ti = i;
                            tj = j;
                            tk = k;
                            tl = l;
                            cn = 1;
                        }
                        else if(pt > mmx)
                        {
                            mmx = pt;
                            ti = i;
                            tj = j;
                            tk = k;
                            tl = l;
                            cn = 1;
                        }
                        else if (pt == mmx)
                        {
                            cn++;
                            int rdm = r.Next(cn);
                            if (rdm == 1)
                            {
                                mmx = pt;
                                ti = i;
                                tj = j;
                                tk = k;
                                tl = l;


                            }
                        }
                        tab[i, j] = tab[k, l];
                        tab[k, l] = p;
                        nb++;
                    }


                }

        }
        if (nb==0)
        {
            mmx = -5000;
            ti = 0;
            tj = 0;
            tk = 0;
            tl = 0;
        }
        this.st = 1;

    }
    public void Solcalcul2()
    {
        //tab = tab2;
        mmx = -5000;
        int  p, pt, a = 0, b = 0, c = 0, d = 0,ne=0;

        int j, k , l , cn = 0;
        nb = 0;

        for (j = 0; j < 8; j++)
        {
            if (((this.tour == 0) && (tab[ind, j] <= 16) && (tab[ind, j] > 0)) || ((this.tour == 1) && (tab[ind, j] >= 17)))
            {
                for (k = 0; k < 8; k++)
                    for (l = 0; l < 8; l++)
                    {
                        if (Verify(ind, j, k, l))
                        {
                            p = tab[k, l];
                            pt = Pointp(p) ;

                            tab[k, l] = tab[ind, j];
                            tab[ind, j] = 0;

                            if (pr > 1) pt = pt - Solcalcul(1 - this.tour, pr - 1, ref a, ref b, ref c, ref d,ref ne);
                            if (nb==0)
                            {
                                mmx = pt;
                                ti = ind;
                                tj = j;
                                tk = k;
                                tl = l;
                                cn = 1;
                            }
                            else if (pt > mmx)
                            {
                                mmx = pt;
                                ti = ind;
                                tj = j;
                                tk = k;
                                tl = l;
                                cn = 1;
                            }
                            else if (pt == mmx)
                            {
                                cn++;
                                int rdm = r.Next(cn);
                                if (rdm == 1)
                                {
                                    mmx = pt;
                                    ti = ind;
                                    tj = j;
                                    tk = k;
                                    tl = l;


                                }
                            }
                            tab[ind, j] = tab[k, l];
                            tab[k, l] = p;
                            nb++;
                        }


                    }

            }
        }



            
        if (nb==0)
        {
            mmx = -5000;
            ti = 0;
            tj = 0;
            tk = 0;
            tl = 0;
        }
        this.st = 1;
    }
    public int Solcalcul(int tr, int pr, ref int i0, ref int j0, ref int i1, ref int j1,ref int nb2)
    {
        int mx = -5000, p , pt , a = 0, b = 0, c = 0, d = 0,ne=0;
        nb2 = 0;

        int i , j, k , l, cn = 0;

        for (i = 0; i < 8; i++)
            for (j = 0; j < 8; j++)
            {
                if (((tr == 0) && (tab[i, j] <= 16) && (tab[i, j] > 0)) || ((tr == 1) && (tab[i, j] >= 17)))
                {
                    for (k = 0; k < 8; k++)
                        for (l = 0; l < 8; l++)
                        {
                            if (Verify(i, j, k, l))
                            {
                                p = tab[k, l];
                                pt = Pointp(p) ;

                                tab[k, l] = tab[i, j];
                                tab[i, j] = 0;
                                if ((p != 5) && (p != 29))
                                {
                                    if (pr > 1) pt = pt - Solcalcul(1 - tr, pr - 1, ref a, ref b, ref c, ref d, ref ne);
                                }
                                if (nb2==0)
                                {
                                    mx = pt;
                                    i0 = i;
                                    j0 = j;
                                    i1 = k;
                                    j1 = l;
                                    cn = 1;
                                    
                                }
                                else if (pt>mx)
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
                                    int rdm = r.Next(cn);
                                    if (rdm == 1)
                                    {
                                        mx = pt;
                                        i0 = i;
                                        j0 = j;
                                        i1 = k;
                                        j1 = l;                                   

                                    }
                                }
                                tab[i, j] = tab[k, l];
                                tab[k, l] = p;
                                nb2++;

                            }


                        }
                }




            }
        if (nb2==0)
        {
            mx = -5000;
            i0 = 0;
            i1 = 0;
            j0 = 0;
            j1 = 0;
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
    private bool Vide2(int i0, int j0, int i1, int j1)
    {
        bool b ;
        if (Math.Abs(i0 - i1) != Math.Abs(j0 - j1)) return false;
        else if ((i0 - i1) == (j0 - j1))
        {
            int i3 = i0, j3 = j0, i4 = i1;


            if (i0 > i1) { i3 = i1; j3 = j1; i4 = i0; }
            i3++; j3++;

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
            int i3 = i0, j3 = j0, i4 = i1 ;
            if (i0 > i1) { i3 = i1; j3 = j1; i4 = i0;  }
            i3++; j3--;

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
    private bool Vide1(int i0, int j0, int i1, int j1)
    {
        bool b ;
        if (i0 == i1)
        {
            if (Math.Abs(j0 - j1) < 2) return true;
            else
            {
                int j , j3 = j0, j4 = j1;
                if (j3 > j4) { j3 = j1; j4 = j0; }
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

    private bool Verifyl(int i0, int j0, int i1, int j1)
    {

        if ((Math.Abs(i0 - i1) == 1) && (Math.Abs(j0 - j1) == 2)) return true;
        else if ((Math.Abs(i0 - i1) == 2) && (Math.Abs(j0 - j1) == 1)) return true;
        return false;

    }
    public bool Verify(int i0, int j0, int i1, int j1)
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
            if ((Math.Abs(i0 - i1) + Math.Abs(j0 - j1) == 1) || ((Math.Abs(i0 - i1) == 1) && (Math.Abs(j0 - j1) == 1)))
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
                else if ((j0 == 1) && (j1 == 3) && (tab[i0, 2] == 0)) return true;
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
                else if ((j0 == 6) && (j1 == 4) && (tab[i0, 5] == 0)) return true;
                else if ((j0 == j1 + 1)) return true;
                else return false;
            }
            else if (Math.Abs(i0 - i1) == 1)
            {
                if ((tab[i1, j1] < 17) && (tab[i1, j1] > 0) && (j0 == j1 + 1)) return true;
                else return false;
            }
            else return false;
        }
        else return false;
    }
}
