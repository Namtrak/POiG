﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaPilkarze
{
    internal class Pilkarz
    {
        #region Wlasciwosci pilkarzy

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public uint Wiek { get; set; }
        public uint Waga { get; set; }

        #endregion

        #region Constructor

        public Pilkarz(string imie, string nazwisko, ushort wiek, ushort waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }

        public Pilkarz(string imie, string nazwisko) : this(imie, nazwisko, 30, 75) { }

        #endregion

        #region Metody

        //Sprawdzenie czy obiekt ma ten sam stan co biezaca instancja
        public bool CzyJestTenSam(Pilkarz pilkarz)
        {
            if (pilkarz.Nazwisko != Nazwisko)
            {
                return false;
            }

            if (pilkarz.Imie != Imie)
            {
                return false;
            }

            if (pilkarz.Wiek != Wiek)
            {
                return false;
            }

            if (pilkarz.Waga != Waga)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{Nazwisko} {Imie} lat: {Wiek} waga: {Waga} kg";
        }

        public string ToFileFormat()
        {
            return $"{Nazwisko}|{Imie}|{Wiek}|{Waga}";
        }

        public static Pilkarz CreateFromString(string sPilkarz)
        {
            string imie, nazwisko;
            ushort wiek, waga;
            var pola = sPilkarz.Split('|');

            if (pola.Length == 4)
            {
                imie = pola[0];
                nazwisko = pola[1];
                wiek = ushort.Parse(pola[2]);
                waga = ushort.Parse(pola[3]);

                return new Pilkarz(imie, nazwisko, wiek, waga);
            }

            throw new Exception("Błędny format danych z pliku");
        }

        #endregion
    }
}
