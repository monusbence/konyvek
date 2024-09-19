namespace Könyvek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Konyv> konyvLista = new List<Konyv>();
            using (StreamReader sr = new StreamReader("konyvek.txt"))
            {
                string sor;
                while (!sr.EndOfStream)
                {
                    sor = sr.ReadLine();
                    string[] adatok = sor.Split(',');
                    string cim = adatok[0];
                    string szerzo = adatok[1];
                    int kiadasiEv = int.Parse(adatok[2]);
                    int oldalSzam = int.Parse(adatok[3]);
                    string mufaj = adatok[4];

                    Konyv konyvek = new Konyv(cim, szerzo, kiadasiEv, oldalSzam, mufaj);
                    konyvLista.Add(konyvek);
                }
            }

            Console.Write("Add meg a keresett szerző nevét: ");
            string keresettSzerzo = Console.ReadLine();
            KonyvekKereseseSzerzoSzerint(konyvLista, keresettSzerzo);

            Konyv legnagyobbKonyv = LegnagyobbOldalszamuKonyv(konyvLista);
            Console.WriteLine($"A legnagyobb oldalszámú könyv: {legnagyobbKonyv.Cim}, {legnagyobbKonyv.OldalSzam} oldal.");

            SorbarendezesKiadasiEvSzerint(konyvLista);

            KonyvekCsoportositasaMufajSzerint(konyvLista);


        }

        static Konyv LegnagyobbOldalszamuKonyv(List<Konyv> konyvLista)
        {
            Konyv legnagyobbKonyv = konyvLista[0];

            foreach (var konyv in konyvLista)
            {
                if (konyv.OldalSzam > legnagyobbKonyv.OldalSzam)
                {
                    legnagyobbKonyv = konyv;
                }
            }

            return legnagyobbKonyv;
        }

        static void KonyvekKereseseSzerzoSzerint(List<Konyv> konyvLista, string szerzo)
        {
            bool vanTalalat = false;

            foreach (var konyv in konyvLista)
            {
                if (konyv.Szerzo.ToLower() == szerzo.ToLower())
                {
                    Console.WriteLine($"Cím: {konyv.Cim}, Szerző: {konyv.Szerzo}, Kiadási év: {konyv.KiadasiEv}, Oldalszám: {konyv.OldalSzam}, Műfaj: {konyv.Mufaj}");
                    vanTalalat = true;
                }
            }

            if (!vanTalalat)
            {
                Console.WriteLine($"Nincs találat a(z) {szerzo} nevű szerzőre.");
            }
        }

        static void SorbarendezesKiadasiEvSzerint(List<Konyv> konyvLista)
        {
            var rendezettLista = konyvLista.OrderBy(konyv => konyv.KiadasiEv).ToList();

            Console.WriteLine("Könyvek kiadási év szerinti növekvő sorrendben:");
            foreach (var konyv in rendezettLista)
            {
                Console.WriteLine($"Cím: {konyv.Cim}, Szerző: {konyv.Szerzo}, Kiadási év: {konyv.KiadasiEv}, Oldalszám: {konyv.OldalSzam}, Műfaj: {konyv.Mufaj}");
            }
        }

        static void KonyvekCsoportositasaMufajSzerint(List<Konyv> konyvLista)
        {
            var mufajCsoportok = konyvLista.GroupBy(konyv => konyv.Mufaj);

            foreach (var csoport in mufajCsoportok)
            {
                Console.WriteLine($"Műfaj: {csoport.Key}, Könyvek száma: {csoport.Count()}");

                foreach (var konyv in csoport)
                {
                    Console.WriteLine($"  Cím: {konyv.Cim}, Szerző: {konyv.Szerzo}, Kiadási év: {konyv.KiadasiEv}, Oldalszám: {konyv.OldalSzam}");
                }
                Console.WriteLine();
            }
        }
    }
}
