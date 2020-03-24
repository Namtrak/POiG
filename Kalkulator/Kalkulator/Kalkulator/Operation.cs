using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    /// <summary>
    /// Przetrzymuje informacje na temat operacji kalkulatora
    /// </summary>
    public class Operation
    {
        #region Properties

        /// <summary>
        /// Operacja lewej strony
        /// </summary>
        public string LeftSide { get; set; }

        /// <summary>
        /// Operacja prawej strony
        /// </summary>
        public string RightSide { get; set; }

        /// <summary>
        /// Typ wykonywanej operacji
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Wewnętrzna operacja, ktora ma byc wykonana przed obecna operacja
        /// </summary>
        public OperationCanceledException InnerOperation { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Domyslny konstruktor
        /// </summary>
        public Operation()
        {
            //Utworzenie zmiennych typu string w celu posbycia sie wartosci null
            this.LeftSide = string.Empty;
            this.RightSide = string.Empty;
        }

        #endregion
    }
}
