namespace repulokOroklodes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("gepek.txt");
            List<Repulo> gepek=new List<Repulo>();
            //beolvasás mentés listába
            foreach (string s in sorok)
            {
                try
                {
                    string[] adatok = s.Split(";");
                    string lajstrom = adatok[1];
                    string nev=adatok[2];
                    List<string> felszereltseg = adatok[3].Split(",").ToList();
                    int ertek = int.Parse(adatok[4]);
                    if (adatok[0] == "U")
                    {
                        int ulesek=int.Parse(adatok[5]);
                        gepek.Add(new UtasszallitoGep(lajstrom, nev, felszereltseg, ertek, ulesek));
                    }
                    else if(adatok[0] == "T")
                    {
                        int maxKg=int.Parse(adatok[5]);
                        gepek.Add(new TeherszallitoGep(lajstrom,nev,felszereltseg,ertek,maxKg));
                    }
                }
                catch (Exception e)
                {

                }
            }
            foreach (var elem in gepek)
            {
                Console.WriteLine(elem);
            }

            //gépek kiírása külön fájlokba
            List<string> utasszallitok = new List<string>();
            List<string> teherszallitok=new List<string>();
            foreach (var elem in gepek)
            {
                if (elem is UtasszallitoGep)
                {
                    utasszallitok.Add(elem.ToString());
                }
                else
                {
                    teherszallitok.Add(elem.ToString());

                }
            }
            File.WriteAllLines("utasszallitok.txt", utasszallitok);
            File.WriteAllLines("teherszallitok.txt", teherszallitok);

            Console.WriteLine();
            //fejlesztések fájl beolvasás
            string[] felszereltsegekstr = File.ReadAllLines("felszereltsegek.txt");
            Dictionary<string, int> felszereltsegek= new Dictionary<string, int>();
            foreach(var  elem in felszereltsegekstr)
            {
                string felsz = elem.Split(",")[0];
                int ar =int.Parse(elem.Split(",")[1]);
                if (!felszereltsegek.ContainsKey(felsz))
                {
                    felszereltsegek.Add(felsz, ar);
                }
            }
            Console.WriteLine("Felszereltség neve | Ára");
            foreach(var item in felszereltsegek)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

        }
    }
}
