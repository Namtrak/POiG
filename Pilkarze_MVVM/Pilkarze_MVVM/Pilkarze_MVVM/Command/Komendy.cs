using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pilkarze_MVVM.Command
{
    public class Komendy : ICommand
    {
        #region Metody związane z komendami
        private readonly Action<object> wykonanie;
        private readonly Predicate<object> moznawykonac;

        public Komendy(Action<object> wykonanie1, Predicate<object> moznawykonac1)
        {
            if (wykonanie1 == null)
            {
                throw new ArgumentNullException(nameof(wykonanie1));
            }
            else
            {
                wykonanie = wykonanie1;
                moznawykonac = moznawykonac1;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (moznawykonac != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (moznawykonac != null) CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parametr)
        {
            return moznawykonac == null ? true : moznawykonac(parametr);
        }

        public void Execute(object parametr)
        {
            wykonanie(parametr);
        }
        #endregion
    }
}
