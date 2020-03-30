using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListaPilkarze
{
    static class ZapisOdczytDoPliku
    {
        #region Zapis do pliku

        public static void ZapisPilkarzyDoPliku(string plik, Pilkarz[] listapilkarzy)
        {
            using (StreamWriter strumien = new StreamWriter(plik))
            {
                foreach (var p in listapilkarzy)
                {
                    strumien.WriteLine(p.ToFileFormat());
                }

                strumien.Close();
            }
        }

        #endregion

        #region Odczyt z pliku

        public static Pilkarz[] OdczytPilkarzyZPliku(string plik)
        {
            Pilkarz[] pilkarze = null;

            if (File.Exists(plik))
            {
                var sPilkarze = File.ReadAllLines(plik);
                var n = sPilkarze.Length;

                if (n > 0)
                {
                    pilkarze = new Pilkarz[n];

                    for (int i = 0; i < n; i++)
                    {
                        pilkarze[i] = Pilkarz.CreateFromString(sPilkarze[i]);
                    }

                    return pilkarze;
                }
            }
            return pilkarze;
        }

        #endregion
    }
}
