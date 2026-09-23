using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repulokOroklodes
{
    public class UtasszallitoGep:Repulo
    {

        public int ulesekSzama { get; private set; }

        public UtasszallitoGep(string lajstrom, string neve, List<string> felszereltsegek, int ertek, int ulesekszama) : base(lajstrom, neve, felszereltsegek, ertek)
        {
            ulesekSzama = ulesekszama;
        }

        public override string? ToString()
        {
            return $"U;{base.ToString()};{ulesekSzama}";
        }
    }
}
