using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    /// <summary>
    /// Podstawowy prosty kalkulator
    /// </summary>
    public partial class a : Form
    {
        #region Constructor
        /// <summary>
        /// Domyślny konstruktor
        /// </summary>
        public a()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Clear Methods

        private void DelButton_Click(object sender, EventArgs e)
        {
            //Usuwa wartosc zaraz po wybranym znaku
            RemoveTextValue();
            //Koncentruje tekst wprowadzany przez użytkownika
            FocusInputText();
        }

        /// <summary>
        /// Czyści tekst wprowadzony przez użytkownika
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event arguments</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Usuwa tekst z pola wprowadzanego przez użytkownika
            this.UserInputText.Text = string.Empty;
            //Koncentruje tekst wprowadzany przez użytkownika
            FocusInputText();
        }

        #endregion

        #region Operation Buttons

        private void DivideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            FocusInputText();
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            FocusInputText();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            FocusInputText();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            FocusInputText();
        }

        private void EqualesButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();
            FocusInputText();
        }

        #endregion

        #region Number Methods
        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            FocusInputText();

        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            FocusInputText();

        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            FocusInputText();

        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            FocusInputText();
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            FocusInputText();

        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            FocusInputText();

        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            FocusInputText();

        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            FocusInputText();

        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            FocusInputText();

        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            FocusInputText();
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            FocusInputText();
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Koncentruje tekst wprowadzany przez użytkownika
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        /// <summary>
        /// Wprowadza zadany tekst do okna danych wprowadzonych przez użytkownika
        /// </summary>
        /// <param name="value"></param>
        private void InsertTextValue(string value)
        {
            //Zapamiętuje początek wyboru
            var selectionStart = this.UserInputText.SelectionStart;
            
            //Ustawia nowy tekst
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, value);

            //Przywraca początek wyboru
            this.UserInputText.SelectionStart = selectionStart + value.Length;
            
            //Ustawia długość wyboru na 0
            this.UserInputText.SelectionLength = 0;
        }

        /// <summary>
        ///Usuwa wpisany tekst z okna danych wprowadzonych przez użytkownika
        /// </summary>
        /// <param name="value"></param>
        private void RemoveTextValue()
        {
            //Jeżeli nie ma wartości do usunięcia to return
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
            {
                return;
            }
            
            //Zapamiętuje początek wyboru
            var selectionStart = this.UserInputText.SelectionStart;
            
            //Usuwa znak po prawej stronie od wyboru
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            //Przywraca początek wyboru
            this.UserInputText.SelectionStart = selectionStart;
            
            //Ustawia wybraną długość na zero
            this.UserInputText.SelectionLength = 0;
        }

        /// <summary>
        /// Oblicza podane równanie i wyrzuca odpowiedź do etykiety użytkownika
        /// </summary>
        private void CalculateEquation()
        {
            this.CalculationResultsText.Text = ParseOperation();

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
                var input = this.UserInputText.Text;

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
                    var myString = "0123456789.";
                    if(myString.Any(character => input[i] == character))
                    {
                        if(leftSide)
                        {
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        }
                        else
                        {
                            operation.RightSide = AddNumberPart(operation.RightSide, input[i]);

                        }
                    }
                    //Warunek sprawdzający czy dany znak jest operatorem
                    else if("+-*/.".Any(c => input[i] == c))
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
                            if(operation.LeftSide.Length == 0)
                            {
                                //Sprawdź czy operator nie jest minusem
                                if(operatorType != OperationType.Minus)
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

                return string.Empty;
            }
            catch(Exception ex)
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
            if(string.IsNullOrEmpty(operation.LeftSide) || !double.TryParse(operation.LeftSide,out left))
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
                switch(operation.OperationType)
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
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Nieudało się obliczyć operacji {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }

            return string.Empty;
        }

        /// <summary>
        /// Przyjmuje znak i zwraca znany typ operacji<see cref="OperationType"/>
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private OperationType GetOperationType(char character)
        {
            switch(character)
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
            if (newCharacter == '.' && currentNumber.Contains('.'))
            {
                throw new InvalidOperationException($"Numer {currentNumber} zawiera już . u bue nie może być dodany.");
            }

            return currentNumber + newCharacter;
        }

        #endregion
    }
}
