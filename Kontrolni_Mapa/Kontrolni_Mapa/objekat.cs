using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_test
{
    public enum VrstaObjekta { Default, Muzej, Galerija, Restoran, Klub, Igraonica, Prodavnica };
    public static class EnumToString
    {
        static Dictionary<VrstaObjekta, string> Strings = new Dictionary<VrstaObjekta, string>()
        {
            {0, "Default" },
            {(VrstaObjekta)1, "Muzej" },
            {(VrstaObjekta)2, "Galerija" },
            {(VrstaObjekta)3, "Restoran" },
            {(VrstaObjekta)4, "Klub" },
            {(VrstaObjekta)5, "Igraonica" },
            {(VrstaObjekta)6, "Prodavnica" }
        };
        public static string StringOf(VrstaObjekta obj)
        {
            try
            {
                return Strings[obj];
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }

    public class Objekat
    {
        #region Static
        internal static class Default
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
            public static VrstaObjekta Vrsta
            {
                get
                { return VrstaObjekta.Default; }
            }
            public static int Ocena
            {
                get
                { return 0; }
            }
            public static string Naziv
            {
                get
                { return "default-objekat-name"; }
            }
        }
        #endregion

        #region Fields
        int x, y;
        VrstaObjekta vrsta;
        int ocena;
        string naziv;
        #endregion
        #region Properties
        public int X
        {
            get
            { return x; }
            set
            { x = value; }
        }
        public int Y
        {
            get
            { return y; }
            set
            { y = value; }
        }
        public VrstaObjekta Objekta
        {
            get
            { return vrsta; }
            set
            { vrsta = value; }
        }
        public int Ocena
        {
            get
            { return ocena; }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    ocena = value;
                }
            }
        }
        public string Naziv
        {
            get
            { return naziv; }
            set
            { naziv = value; }
        }
        #endregion
        #region Constructors
        public Objekat()
        {
            x = Default.X;
            y = Default.Y;
            vrsta = Default.Vrsta;
            ocena = Default.Ocena;
            naziv = Default.Naziv;
        }
        public Objekat(int x, int y)
        {
            this.x = x;
            this.y = y;
            vrsta = Default.Vrsta;
            ocena = Default.Ocena;
            naziv = Default.Naziv;
        }
        public Objekat(VrstaObjekta vrsta)
        {
            x = Default.X;
            y = Default.Y;
            this.vrsta = vrsta;
            ocena = Default.Ocena;
            naziv = Default.Naziv;
        }
        public Objekat(string naziv)
        {
            x = Default.X;
            y = Default.Y;
            vrsta = Default.Vrsta;
            ocena = Default.Ocena;
            this.naziv = naziv;
        }
        public Objekat(int x, int y, VrstaObjekta vrsta, string naziv)
        {
            this.x = x;
            this.y = y;
            this.vrsta = vrsta;
            ocena = Default.Ocena;
            this.naziv = naziv;
        }
        public Objekat(int x, int y, VrstaObjekta vrsta, string naziv, int ocena)
        {
            this.x = x;
            this.y = y;
            this.vrsta = vrsta;
            this.ocena = ocena;
            this.naziv = naziv;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return string.Format("({0},{1}) - \"{2}\" ({3}) - ({4}/5)", X, Y, Naziv, EnumToString.StringOf(vrsta), Ocena);
        }
        #endregion
    }
}
