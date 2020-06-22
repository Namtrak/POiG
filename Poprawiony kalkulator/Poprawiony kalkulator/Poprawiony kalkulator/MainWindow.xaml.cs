using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poprawiony_kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Domyślny konstruktor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Czyści tekst wprowadzony przez użytkownika
        /// </summary>
        #region Clear Methods
        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            //Usuwa tekst z pola wprowadzanego przez użytkownika
            this.TextBox.Text = string.Empty;
            //Koncentruje tekst wprowadzany przez użytkownika
            FocusInputText();
        }

        private void ButtonDEL_Click(object sender, RoutedEventArgs e)
        {
            //Usuwa wartosc zaraz po wybranym znaku
            RemoveTextValue();
            //Koncentruje tekst wprowadzany przez użytkownika
            FocusInputText();
        }
        #endregion


        #region Number Methods
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("0");
            FocusInputText();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("1");
            FocusInputText();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("2");
            FocusInputText();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("3");
            FocusInputText();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("4");
            FocusInputText();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("5");
            FocusInputText();
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("6");
            FocusInputText();
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("7");
            FocusInputText();
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("8");
            FocusInputText();
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("9");
            FocusInputText();
        }
        #endregion


        #region Operation Buttons
        private void ButtonMul_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("*");
            FocusInputText();
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("/");
            FocusInputText();
        }

        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("-");
            FocusInputText();
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue("+");
            FocusInputText();
        }

        private void ButtonEqua_Click(object sender, RoutedEventArgs e)
        {
            CalculateEquation();
            FocusInputText();
        }

        private void ButtonCom_Click(object sender, RoutedEventArgs e)
        {
            InsertTextValue(",");
            FocusInputText();
        }
        #endregion


        #region TextBoxes
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion


        #region Private Helpers
        /// <summary>
        /// Koncentruje tekst wprowadzany przez użytkownika
        /// </summary>
        private void FocusInputText()
        {
            this.TextBox.Focus();
        }

        /// <summary>
        /// Wprowadza zadany tekst do okna danych wprowadzonych przez użytkownika
        /// </summary>
        /// <param name="value"></param>
        private void InsertTextValue(string value)
        {
            //Zapamiętuje początek wyboru
            var selectionStart = this.TextBox.SelectionStart;

            //Ustawia nowy tekst
            this.TextBox.Text = this.TextBox.Text.Insert(this.TextBox.SelectionStart, value);

            //Przywraca początek wyboru
            this.TextBox.SelectionStart = selectionStart + value.Length;

            //Ustawia długość wyboru na 0
            this.TextBox.SelectionLength = 0;
        }

        /// <summary>
        ///Usuwa wpisany tekst z okna danych wprowadzonych przez użytkownika
        /// </summary>
        /// <param name="value"></param>
        private void RemoveTextValue()
        {
            //Jeżeli nie ma wartości do usunięcia to return
            if (this.TextBox.Text.Length < this.TextBox.SelectionStart + 1)
            {
                return;
            }

            //Zapamiętuje początek wyboru
            var selectionStart = this.TextBox.SelectionStart;

            //Usuwa znak po prawej stronie od wyboru
            this.TextBox.Text = this.TextBox.Text.Remove(this.TextBox.SelectionStart, 1);

            //Przywraca początek wyboru
            this.TextBox.SelectionStart = selectionStart;

            //Ustawia wybraną długość na zero
            this.TextBox.SelectionLength = 0;
        }

        /// <summary>
        /// Oblicza podane równanie i wyrzuca odpowiedź do etykiety użytkownika
        /// </summary>
        private void CalculateEquation()
        {
            this.TextBlock.Text = ParseOperation();

            FocusInputText();
        }

        /// <summary>
        /// Funkcja analizująca równania wprowadzone przez użytkownika, a następnie zwraca wynik
        /// </summary>
        /// <returns></returns>
        private string ParseOperation()
        {
            try
            {
                //Pobiera dane wprowadzone przez użytkownika
                var input = this.TextBox.Text;

                //Usuwa wszystkie spacje
                input = input.Replace(" ", "");

                //Tworzy nową wyższorzędną operację
                var operation = new Operation();
                var leftSide = true;

                //Pętla poprzez każdy znak wejścia
                //Zaczyna działanie od lewej do prawej strony
                for (int i = 0; i < input.Length; i++)
                {
                    //Warunek sprawdzajacy czy dany znak jest literą
                    var myString = "0123456789.,";
                    if (myString.Any(character => input[i] == character))
                    {
                        if (leftSide)
                        {
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        }
                        else
                        {
                            operation.RightSide = AddNumberPart(operation.RightSide, input[i]);

                        }
                    }
                    //Warunek sprawdzający czy dany znak jest operatorem
                    else if ("+-*/,".Any(c => input[i] == c))
                    {
                        //Jeżeli jesteśmy po prawej stronie już to nie musimy obliczać obecnej operacji oraz ustawiać wyniku na lewą stronę następnej operacji
                        if (!leftSide)
                        {
                            //Pobierz typ operatora
                            var operatorType = GetOperationType(input[i]);

                            //Sprawdź czy po prawej stronie jest liczba
                            if (operation.RightSide.Length == 0)
                            {
                                //Sprawdź czy operator nie jest minusem
                                if (operatorType != OperationType.Minus)
                                {
                                    throw new InvalidOperationException($"Operator (+ * / albo więcej niż jeden -) określony bez numeru po prawej stronie");
                                }

                                //Operator jest minusem i nie została żadna lewa cyfra, a więc dodaj minus do cyfry
                                operation.RightSide += input[i];
                            }
                            else
                            {
                                //Oblicz poprzednie równanie i ustaw do lewej strony
                                operation.LeftSide = CalculateOperation(operation);

                                //Ustaw nowy operator 
                                operation.OperationType = operatorType;

                                //Wyczyść poprzedni prawy numer
                                operation.RightSide = string.Empty;
                            }
                        }
                        else
                        {
                            //Pobierz typ operatora
                            var operatorType = GetOperationType(input[i]);

                            //Sprawdź czy po lewej stronie jest liczba
                            if (operation.LeftSide.Length == 0)
                            {
                                //Sprawdź czy operator nie jest minusem
                                if (operatorType != OperationType.Minus)
                                {
                                    throw new InvalidOperationException($"Operator (+ * / albo więcej niż jeden -) określony bez numeru po lewej stronie");
                                }

                                //Operator jest minusem i nie została żadna lewa cyfra, a więc dodaj minus do cyfry
                                operation.LeftSide += input[i];
                            }
                            else
                            {
                                //Jest pozostały numer i teraz operator. a więc chcemy iśc do prawej strony

                                //Ustaw typ operacji
                                operation.OperationType = operatorType;

                                //Idż na prawą stronę
                                leftSide = false;
                            }
                        }
                    }
                }

                //Jeżeli skończyliśmy analize składników i nie było żadnych wyjątków to obliczamy obecną operację
                return CalculateOperation(operation);
            }
            catch (Exception ex)
            {
                return $"Nieprawidlowe rownanie. {ex.Message}";
            }
        }

        /// <summary>
        /// Oblicza operacje i zwraca wynik 
        /// </summary>
        /// <param name="operation"></param>
        private string CalculateOperation(Operation operation)
        {
            //Przetrzymuje wartości liczbowe reprezentacji danych typu string
            double left = 0;
            double right = 0;

            //Sprawdzanie czy mamy ważną liczbę z lewej strony
            if (string.IsNullOrEmpty(operation.LeftSide) || !double.TryParse(operation.LeftSide, out left))
            {
                throw new InvalidOperationException($"Lewa strona operacji nie jest numerem {operation.LeftSide}");
            }
            //Sprawdzanie czy mamy ważną liczbę z prawej strony
            if (string.IsNullOrEmpty(operation.RightSide) || !double.TryParse(operation.RightSide, out right))
            {
                throw new InvalidOperationException($"Prawa strona operacji nie jest numerem {operation.RightSide}");
            }

            try
            {
                switch (operation.OperationType)
                {
                    case OperationType.Plus:
                        return (left + right).ToString();
                    case OperationType.Minus:
                        return (left - right).ToString();
                    case OperationType.Multiply:
                        return (left * right).ToString();
                    case OperationType.Divide:
                        return (left / right).ToString();
                    default:
                        throw new InvalidOperationException($"Nieznany typ operatora {operation.OperationType}");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Nieudało się obliczyć operacji {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }
        }

        /// <summary>
        /// Przyjmuje znak i zwraca znany typ operacji<see cref="OperationType"/>
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private OperationType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperationType.Plus;
                case '-':
                    return OperationType.Minus;
                case '/':
                    return OperationType.Divide;
                case '*':
                    return OperationType.Multiply;
                default:
                    throw new InvalidOperationException($"Nieznany typ operatora {character}");
            }
        }

        /// <summary>
        /// Próbuje dodać nowy znak do aktualnego numeru, sprawdzając odpowiednie znaki po kolei
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="currentCharacter"></param>
        /// <returns></returns>
        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            //Sprawdza czy jest . w numerze
            if (newCharacter == ',' && currentNumber.Contains(','))
            {
                throw new InvalidOperationException($"Numer {currentNumber} zawiera już ',' i nie może być dodany.");
            }

            return currentNumber + newCharacter;
        }

        #endregion
    }
}
