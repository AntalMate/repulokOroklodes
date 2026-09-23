using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repulokOroklodes
{
    public class Repulo
    {
        public string lajstrom { get; private set; }
        public string neve { get; private set; }
        public List<string> felszereltsegek { get; private set; }
        public int ertek { get; private set; }

        public Repulo(string lajstrom, string neve, List<string> felszereltsegek, int ertek)
        {
            this.lajstrom = lajstrom;
            this.neve = neve;
            this.felszereltsegek = felszereltsegek;
            this.ertek = ertek;
        }

        public void felszereltsegHozzaadas(string felszereltseg)
        {
            felszereltsegek.Add(felszereltseg);
        }

        public override string? ToString()
        {
            return $"{lajstrom};{neve};{string.Join(',',felszereltsegek)};{ertek}";
        }
    }
}
