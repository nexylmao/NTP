using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_test
{
    public class Mapa
    {
        #region Static
        public static class Default
        {
            public static int Sirina
            {
                get
                { return 100; }
            }
            public static int Visina
            {
                get
                { return 100; }
            }
            public static IEnumerable<Objekat> Objekti
            {
                get
                { return new List<Objekat>(); }
            }
        }
        public static class Center
        {
            public static int X
            {
                get
                { return 0; }
            }
            public static int Y
            {
                get
                { return 0; }
            }
        }
        #endregion

        #region Fields
        int sirina, visina;
        List<Objekat> objekti;
        #endregion
        #region Properties
        public int Sirina
        {
            get
            { return sirina; }
            set
            {
                if(value % 2 != 0)
                {
                    throw new ArgumentException();
                }
                sirina = value;
            }
        }
        public int Visina
        {
            get
            { return visina; }
            set
            {
                if (value % 2 != 0)
                {
                    throw new ArgumentException();
                }
                visina = value;
            }
        }
        public List<Objekat> Objekti
        {
            get
            {
                if(objekti == null)
                {
                    objekti = new List<Objekat>();
                }
                return objekti;
            }
            set
            {
                objekti = value;
            }
        }
        int X_Max
        {
            get
            { return sirina / 2; }
        }
        int X_Min
        {
            get
            { return - (sirina / 2); }
        }
        int Y_Max
        {
            get
            { return visina / 2; }
        }
        int Y_Min
        {
            get
            { return -(visina / 2); }
        }
        #endregion
        #region Constructors
        public Mapa()
        {
            Sirina = Default.Sirina;
            Visina = Default.Visina;
            objekti = (List<Objekat>)Default.Objekti;
        }
        public Mapa(int sirina, int visina)
        {
            Sirina = sirina;
            Visina = visina;
            objekti = (List<Objekat>)Default.Objekti;
        }
        public Mapa(IEnumerable<Objekat> objekti)
        {
            Sirina = Default.Sirina;
            Visina = Default.Visina;
            Objekti = new List<Objekat>();
            foreach(Objekat x in objekti)
            {
                try
                {
                    Dodaj(x);
                }
                catch
                {
                    continue;
                }
            }
        }
        public Mapa(int sirina, int visina, IEnumerable<Objekat> objekti)
        {
            Sirina = sirina;
            Visina = visina;
            Objekti = new List<Objekat>();
            foreach (Objekat x in objekti)
            {
                try
                {
                    Dodaj(x);
                }
                catch
                {
                    continue;
                }
            }
        }
        #endregion
        #region Methods
        public bool ProveriKoordinate(int x, int y)
        {
            if (x >= X_Min && x <= X_Max)
            {
                if (y >= Y_Min && y <= Y_Max)
                {
                    return true;
                }
            }
            return false;
        }
        public double Udaljenost(int x1, int x2, int y1, int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        public double UdaljenostOdCentra(int x, int y)
        {
            return Udaljenost(Center.X, x, Center.Y, y);
        }
        public void Dodaj(Objekat obj)
        {
            try
            {
                if(ProveriKoordinate(obj.X,obj.Y))
                {
                    Objekti.Add(obj);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }
        public double[] Sort()
        {
            try
            {
                // Sort po udaljenost od centra
                double[] udaljenosti = new double[objekti.Count];
                for(int i = 0; i < udaljenosti.Length; i++)
                {
                    udaljenosti[i] = UdaljenostOdCentra(objekti[i].X, objekti[i].Y);
                }
                // sort
                for(int i = 0; i < udaljenosti.Length - 1; i++)
                {
                    int pivot = i;
                    for (int j = i + 1; j < udaljenosti.Length; j++)
                    {
                        if (udaljenosti[pivot] > udaljenosti[j])
                        {
                            pivot = j;
                        }
                    }
                    if(pivot != i)
                    {
                        // swap both double and objekat
                        double swap = udaljenosti[pivot];
                        udaljenosti[pivot] = udaljenosti[i];
                        udaljenosti[i] = swap;
                        Objekat swap2 = objekti[pivot];
                        objekti[pivot] = objekti[i];
                        objekti[i] = swap2;
                    }
                }
                return udaljenosti;
            }
            catch
            {
                throw new Exception();
            }
        }
        public Objekat Nadji(int x, int y, int rastojanje, int ocena)
        {
            try
            {
                double[] udaljenosti = Sort();
                int index = -1, i = 0;
                double min = int.MaxValue;
                while(i < udaljenosti.Length && udaljenosti[i] <= rastojanje)
                {
                    double ud = UdaljenostOdCentra(objekti[i].X, objekti[i].Y);
                    if (objekti[i].Ocena >= ocena && ud < rastojanje)
                    {
                        double udodtacke = Udaljenost(x, objekti[i].X, y, objekti[i].Y);
                        if(udodtacke < min)
                        {
                            index = i;
                            min = udodtacke;
                        }
                    }
                    i++;
                }

                if(index != -1)
                {
                    return objekti[index];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            string returning = string.Empty;
            returning += string.Format("Mapa \n Visina = {0} | Sirina = {1}\n Broj objekata - {2} : \n", Visina, Sirina, Objekti.Count);
            foreach(Objekat x in objekti)
            {
                returning += string.Format("\t{0}\n", x);
            }
            return returning;
        }
        #endregion
    }
}
