using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Könyvek
{
    internal class Konyv
    {
        string cim;
        string szerzo;
        int kiadasiEv;
        int oldalSzam;
        string mufaj;

        public Konyv(string cim, string szerzo, int kiadasiEv, int oldalSzam, string mufaj)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.kiadasiEv = kiadasiEv;
            this.oldalSzam = oldalSzam;
            this.mufaj = mufaj;
        }

        public string Cim { get => cim; set => cim = value; }
        public string Szerzo { get => szerzo; set => szerzo = value; }
        public int KiadasiEv { get => kiadasiEv; set => kiadasiEv = value; }
        public int OldalSzam { get => oldalSzam; set => oldalSzam = value; }
        public string Mufaj { get => mufaj; set => mufaj = value; }
    }
}
