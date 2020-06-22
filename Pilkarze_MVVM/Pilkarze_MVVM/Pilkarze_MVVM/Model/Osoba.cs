using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.Model
{
    public class Osoba
    {
        #region Wlasciwosci pilkarzy
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Waga { get; set; }
        public int Wiek { get; set; }
        #endregion


        #region Metoda Calosc oraz ToString
        public string Calosc
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, wiek: {Wiek}, waga: {Waga}kg";
        }
        #endregion


        #region Metody Osoba
        public Osoba()
        {
            Imie = "Osoba";
            Nazwisko = "Testowa";
            Waga = 76;
            Wiek = 99;
        }

        public Osoba(string imie, string nazwisko, int waga, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Waga = waga;
            Wiek = wiek;
        }
        #endregion
    }
}
