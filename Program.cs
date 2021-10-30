using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004
{
    class Program
    {
        static void Main(string[] args)
        {   //okj szoftverfejleszto - 2005 26
            /* 1 */
            /* 2 */
            string[] sorok =  File.ReadAllLines("eredmenyek.csv", Encoding.UTF8);
            List<Adat> adatok = new List<Adat>();
            foreach (string sor in sorok.Skip(1))
            {
                adatok.Add(new Adat(sor));
            }

            int adatokszama = adatok.Count();
            //hazai	idegen	hazai_pont	idegen_pont	helyszín	időpont
            int hazai = 0;
            int idegen = 0;

            for (int i = 0; i < adatokszama; i++)
            {
                if (adatok[i].HazaiCsapatNeve == "Real Madrid")
                {
                    hazai++;
                }
                if (adatok[i].IdegenCsapatNeve == "Real Madrid")
                {
                    idegen++;
                }

            }
            Console.WriteLine($"3. Feladat: A Real Madrid {hazai} alkalommal játszott hazai csapatként" +
                $"és {idegen} alkalommal idegenként");

            /* 4  Hatátrozzameg és írja ki a minta szerint, hogy volt-e döntetlen mérkőzés! */
            bool vanDontetlen = true;
            int j = 0;

            int maxi = 0;
            for (int i = 0; i < adatokszama; i++)
            {
                if (adatok[j].HazaiPontok == adatok[i].IdegenPontok)
                {
                    vanDontetlen = false;
                    maxi = j;
                }
            }
                
            Console.WriteLine(vanDontetlen ? "4.-es feladat: Igen, van döntetlen" : "4. feladat: Nem, nincs döntetlen");


            /* 5 Határozza meg és írja ki a minta szerint, hogy a barcelonai csapatnak mi a pontos neve!*/
            string keresettCsapat = "";
            for (int i = 0; i < adatokszama; i++)
            {
                // && adatok[i].Helyszin.Contains("Barcelona")IdegenCsapatNeve
                if (adatok[i].HazaiCsapatNeve.Contains("Barcelona"))
                {
                    keresettCsapat = adatok[i].HazaiCsapatNeve;
                }
            }
            Console.WriteLine($"5. feladat: A keresett csapat a(z) {keresettCsapat}");

            /* 6  Hatánozza meg és írja ki a minta szerint, hogy 2004. november 21-én mely csapatok
            mérkőzéseket, és milyen eredmény született!*/

            Console.WriteLine("6. feladat: ");
            for (int i = 0; i < adatokszama; i++)
            {
                if (adatok[i].Idopont.Year == 2004 && adatok[i].Idopont.Month==11 && adatok[i].Idopont.Day==21)
                {
                    Console.WriteLine($"\t{adatok[i].HazaiCsapatNeve} - {adatok[i].IdegenCsapatNeve} ({adatok[i].HazaiPontok}:{adatok[i].IdegenPontok}) ");
                }
            }

            /* 7 Írja ki a stadionokat ahol 20-nál több alk. volt meccs. mögötte mérkőzések szám!*/

            Dictionary<string, int> lista = new Dictionary<string, int>();
            foreach (Adat adat in adatok)
            {

                string kulcs = adat.Helyszin;
                if (lista.ContainsKey(kulcs))
                {
                    lista[kulcs]++;
                }
                else
                {
                    lista.Add(kulcs, 1);
                }
                
            }
            Console.WriteLine("7. Feladat:");
            foreach (var item in lista)
            {
                if (item.Value > 20)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
                
            }
            



            Console.ReadKey();
        }
    }
}
