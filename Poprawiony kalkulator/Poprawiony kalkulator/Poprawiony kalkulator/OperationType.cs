using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprawiony_kalkulator
{
    /// <summary>
    /// Typy operacji, które kalkulator może wykonywać
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// Dodawanie dwóch liczb
        /// </summary>
        Plus,

        /// <summary>
        /// Odejmowanie jednej liczby od drugiej
        /// </summary>
        Minus,

        /// <summary>
        /// Dzielenie jednej liczby przez drugą
        /// </summary>
        Divide,

        /// <summary>
        /// Mnożenie jednej liczby przez drugą
        /// </summary>
        Multiply
    }
}
