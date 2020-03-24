using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Krótka notka o aplikacji kalkulator
  Jest to wersja uproszczona, gdyż nie zdołałem zrobić obsługi wszystkich wyjątków i rozbudować możliwości kalkulatora.
  Z uwagi na niesprawne w 100% działanie przetwarzania wprowadzanych równań zaleca się rozważne używanie nawiasów wprowadzając dane.
  Niestety jest to definitywne maksimum moich możliwości z uwagi na problemy zrozumienia algorytmów oraz ogólnie pojętego programowania w
  różnych formach od programowania obiektowego po systemy sztucznej inteligencji. Niestety programowanie nie jest moją mocną stroną, gdyż bardziej
  rozumiem i odnajduję się w wszelkich sprawach związanych z sieciami komputerowymi i ich analizą oraz zarządzaniem.
  Dziękuję za poświęcenie chwili i przeczytanie tej adnotacji do projektu. */

namespace Kalkulator
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new a());
        }
    }
}
