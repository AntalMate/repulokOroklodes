using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repulokOroklodes
{
    public class TeherszallitoGep:Repulo
    {

        public int maxRakomanyKg { get; private set; }

        public TeherszallitoGep(string lajstrom, string neve, List<string> felszereltsegek, int ertek, int maxRakomanyKg) : base(lajstrom, neve, felszereltsegek, ertek)
        {
            this.maxRakomanyKg = maxRakomanyKg;
        }

        public override string? ToString()
        {
            return $"T;{base.ToString()};{maxRakomanyKg}";
        }
    }
}
