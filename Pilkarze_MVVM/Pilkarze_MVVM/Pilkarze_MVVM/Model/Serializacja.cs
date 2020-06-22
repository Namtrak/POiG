using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pilkarze_MVVM.Model
{
    public static class Serializacja_wczytaj_zapisz
    {
        #region Metoda Zapisz serializacji
        public static void Zapisz(string sciezka, List<Osoba> osoba)
        {
            XmlSerializer serializacja = new XmlSerializer(typeof(List<Osoba>));

            using (TextWriter textWriter = new StreamWriter(sciezka))
            {
                serializacja.Serialize(textWriter, osoba);
            }
        }
        #endregion


        #region Metoda Wczytaj serializacji
        public static List<Osoba> Wczytaj(string sciezka)
        {
            List<Osoba> pilkarze = new List<Osoba>();

            XmlSerializer serializacja = new XmlSerializer(typeof(List<Osoba>));

            using (TextReader textWriter = new StreamReader(sciezka))
            {
                pilkarze = serializacja.Deserialize(textWriter) as List<Osoba>;
            }

            return pilkarze;
        }
        #endregion
    }
}
