using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Pilkarze_MVVM.Command;
using Pilkarze_MVVM.Model;

namespace Pilkarze_MVVM.ViewModels
{
    public class ViewModel_Osoby : ViewModel_Base
    {
        #region Zmienne prywatne
        private readonly string path = "pilkarze.txt";

        private ObservableCollection<Osoba> lista = new ObservableCollection<Osoba>();
        private int id = -1;

        private string nameBox = "";
        private string lastNameBox = "";
        private int Weight = 0;
        private int Age = 0;
        #endregion


        #region Wlasciwosci
        public string BoxName
        {
            get { return nameBox; }
            set { nameBox = value; OnPropertyChanged(nameof(BoxName)); }
        }

        public string BoxlastName
        {
            get { return lastNameBox; }
            set { lastNameBox = value; OnPropertyChanged(nameof(BoxlastName)); }
        }

        public int BoxAge
        {
            get { return Age; }
            set { Age = value; OnPropertyChanged(nameof(BoxAge), nameof(LabelAge)); }
        }

        public int BoxWeight
        {
            get { return Weight; }
            set { Weight = value; OnPropertyChanged(nameof(BoxWeight), nameof(LabelWeight)); }
        }

        public string LabelAge
        {
            get { return $"Wiek ({Age})"; }
        }

        public string LabelWeight
        {
            get { return $"Waga ({Weight})"; }
        }
        #endregion


        #region Komendy
        private ICommand dodaj_przycisk = null;
        private ICommand usun_przycisk = null;
        private ICommand edytuj_przycisk = null;
        private ICommand wczytaj = null;
        private ICommand zapisz = null;
        #endregion


        #region Konstruktor
        public ViewModel_Osoby()
        {
            if (File.Exists(path))
            {
                Lista_osob = new ObservableCollection<Osoba>(Serializacja_wczytaj_zapisz.Wczytaj(path));
            }
        }
        #endregion


        #region Metoda CzyDodac
        private bool CzyDodac(string tekst)
        {
            if (String.IsNullOrEmpty(tekst))
            {
                return false;
            }
            if (Regex.IsMatch(tekst, @"\d"))
            {
                return false;
            }

            return true;
        }
        #endregion


        #region Metody Dodaj, Usun oraz Modyfikuj
        private void Dodaj()
        {
            var pilkarz = new Osoba(BoxName, BoxlastName, BoxWeight, BoxAge);

            lista.Add(pilkarz);
            Serializacja_wczytaj_zapisz.Zapisz(path, Lista_osob.ToList());
        }

        private void Usun()
        {
            var atIndex = Id;
            var dialog = MessageBox.Show("Potwierdź usunięcie: ", "Usuń", MessageBoxButton.YesNo);

            if (dialog == MessageBoxResult.Yes)
            {
                Id = -1;
                Lista_osob.RemoveAt(atIndex);

                Serializacja_wczytaj_zapisz.Zapisz(path, Lista_osob.ToList());
            }
        }

        private void Modyfikuj()
        {
            var pilkarz = new Osoba(BoxName, BoxlastName, BoxWeight, BoxAge);
            var dialog = MessageBox.Show("Potwierdź edycje: ", "Edytuj", MessageBoxButton.YesNo);

            if (dialog == MessageBoxResult.Yes)
            {
                Lista_osob.Insert(Id, pilkarz);
                Id -= 1;
                Lista_osob.RemoveAt(Id + 1);

                Serializacja_wczytaj_zapisz.Zapisz(path, Lista_osob.ToList());
            }
        }
        #endregion


        #region Komendy Get/Set
        public ICommand IC_wczytaj
        {
            get
            {
                if (wczytaj == null)
                {
                    Komendy komendy = new Komendy(arg => Lista_osob = new ObservableCollection<Osoba>(Serializacja_wczytaj_zapisz.Wczytaj(path)), arg => File.Exists(path));
                    wczytaj = komendy;
                }

                return wczytaj;
            }
        }

        public ICommand IC_zapisz
        {
            get
            {
                if (zapisz == null)
                {
                    Komendy komendy = new Komendy(arg => Serializacja_wczytaj_zapisz.Zapisz(path, Lista_osob.ToList()), arg => true);
                    zapisz = komendy;
                }

                return zapisz;
            }
        }

        public ICommand IC_edycja
        {
            get
            {
                if (edytuj_przycisk == null)
                {
                    Komendy komendy = new Komendy(arg => Modyfikuj(), arg => CzyDodac(BoxName) && CzyDodac(BoxlastName) && Id > -1);
                    edytuj_przycisk = komendy;
                }

                return edytuj_przycisk;
            }
        }

        public ICommand IC_usun
        {
            get
            {
                if (usun_przycisk == null)
                {
                    Komendy komendy = new Komendy(arg => Usun(), arg => Id > -1);
                    usun_przycisk = komendy;
                }

                return usun_przycisk;
            }
        }

        public ICommand IC_dodaj
        {
            get
            {
                if (dodaj_przycisk == null)
                {
                    Komendy komendy = new Komendy(arg => Dodaj(), arg => CzyDodac(BoxName) && CzyDodac(BoxlastName));
                    dodaj_przycisk = komendy;
                }

                return dodaj_przycisk;
            }
        }
        #endregion


        #region Lista_osoba oraz Id
        public ObservableCollection<Osoba> Lista_osob
        {
            get
            {
                return lista;
            }
            set
            {
                lista = value;
                OnPropertyChanged(nameof(Lista_osob));
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;

                if (id > -1)
                {
                    BoxName = Lista_osob[id].Imie;
                    BoxlastName = Lista_osob[id].Nazwisko;
                    BoxAge = Lista_osob[id].Wiek;
                    BoxWeight = Lista_osob[id].Waga;
                }
                else
                {
                    BoxName = "";
                    BoxlastName = "";
                    BoxAge = 0;
                    BoxWeight = 0;
                }

                OnPropertyChanged(nameof(Id));
            }
        }
        #endregion
    }
}
