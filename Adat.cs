using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004
{
    class Adat
    {   //hazai	idegen	hazai_pont	idegen_pont	helyszín	időpont
        public string HazaiCsapatNeve { get; set; }
        public string IdegenCsapatNeve { get; set; }
        public int HazaiPontok { get; set; }
        public int IdegenPontok { get; set; }
        public string Helyszin { get; set; }
        public DateTime Idopont { get; set; }

        public Adat(string sor)
        {
            string[] s = sor.Split(';');
            HazaiCsapatNeve = s[0];
            IdegenCsapatNeve = s[1];
            HazaiPontok = int.Parse(s[2]);
            IdegenPontok = int.Parse(s[3]);
            Helyszin = s[4];
            Idopont = DateTime.Parse(s[5]);
        }
    }
}
