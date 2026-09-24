namespace repulokOroklodes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("gepek.txt");
            List<Repulo> gepek=new List<Repulo>();
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
            bool futas = true;
            while (futas)
            {
                Console.WriteLine();
                Console.WriteLine("=== REPÜLŐK ===");
                Console.WriteLine("1 - Gépek listázása");
                Console.WriteLine("2 - Új repülő felvitele");
                Console.WriteLine("3 - Gépek kiírása külön fájlokba");
                Console.WriteLine("0 - Mentés és kilépés");
                Console.Write("Választás: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        //repülők kiírása
                        foreach (var elem in gepek)
                        {
                            Console.WriteLine(elem);
                        }
                        break;

                    case "2":
                        //Új repülő
                        Console.WriteLine("Adja meg az új repülő lajstromszámát: ");
                        string ujLajstrom = Console.ReadLine();
                        Console.WriteLine("Adja meg az új repülő nevét: ");
                        string ujNev = Console.ReadLine();

                        //fejlesztések kiírása, bekérése

                        string[] felszereltsegekstr = File.ReadAllLines("felszereltsegek.txt");
                        Dictionary<string, int> felszereltsegek = new Dictionary<string, int>();
                        foreach (var elem in felszereltsegekstr)
                        {
                            string felsz = elem.Split(",")[0];
                            int ar = int.Parse(elem.Split(",")[1]);
                            if (!felszereltsegek.ContainsKey(felsz.ToLower()))
                            {
                                felszereltsegek.Add(felsz.ToLower(), ar);
                            }
                        }
                        Console.WriteLine("Felszereltség neve | Ára");
                        foreach (var item in felszereltsegek)
                        {
                            Console.WriteLine($"{item.Key} | {item.Value}");
                        }

                        Random rnd = new Random();
                        int vegosszeg = rnd.Next(10000000, 40000000);
                        List<string> ujFelszLista = new List<string>();
                        while (true)
                        {
                            Console.WriteLine("Adja meg az új repülő felszereltségét, vagy üssön üres entert ha nem kíván többet hozzáadni: ");
                            string ujfelszereltseg = Console.ReadLine();
                            int ar;
                            if (felszereltsegek.TryGetValue(ujfelszereltseg.ToLower(), out ar))
                            {
                                ujFelszLista.Add(ujfelszereltseg);
                                vegosszeg += ar;
                                Console.WriteLine("Sikeres hozzáadás!");
                            }
                            else if (ujfelszereltseg == "")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen felszereltség!");
                            }
                        }

                        //U/T, mentés
                        while (true)
                        {
                            Console.WriteLine("Kérem adja meg ogy utas- vagy teherszállító (U/T): ");
                            string utInput = Console.ReadLine();
                            if (utInput.ToUpper() == "U")
                            {
                                Console.WriteLine("Adja meg hány utast tud szállítani: ");
                                int ujUtas = int.Parse(Console.ReadLine());
                                Repulo ujRepulo = new UtasszallitoGep(ujLajstrom, ujNev, ujFelszLista, vegosszeg, ujUtas);
                                Console.WriteLine("A repülője: ");
                                Console.WriteLine(ujRepulo);
                                gepek.Add(ujRepulo);
                                break;

                            }
                            else if (utInput.ToUpper() == "T")
                            {
                                Console.WriteLine("Adja meg hány Kg rakományt tud szállítani: ");
                                int ujKg = int.Parse(Console.ReadLine());
                                Repulo ujRepulo = new TeherszallitoGep(ujLajstrom, ujNev, ujFelszLista, vegosszeg, ujKg);
                                Console.WriteLine("A repülője: ");
                                Console.WriteLine(ujRepulo);
                                gepek.Add(ujRepulo);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Rossz bemenet!");
                            }
                        }
                        break;

                    case "3":
                        //Mentés külön fájlokba
                        List<string> utasszallitok = new List<string>();
                        List<string> teherszallitok = new List<string>();
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
                        Console.WriteLine("A két fájl elkészült!");
                        break;

                    case "0":
                        File.WriteAllText("gepek.txt", string.Join("\n", gepek));
                        Console.WriteLine("Elmentve! Kilépés!");
                        futas = false;
                        break;

                    default:
                        Console.WriteLine("Rossz bemenet!");
                        break;

                }

            }
            
        }
    }
}
