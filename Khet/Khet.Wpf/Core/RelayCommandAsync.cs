using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Khet.Wpf.Core
{
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<object, Task> _executeAsync;

        public RelayCommandAsync(Func<object, Task> executeAsync)
        {
            _executeAsync = executeAsync;
        }

        public async void Execute(object parameter)
        {
            await _executeAsync(parameter);
        }

        public bool CanExecute(object parameter) => true;

        public event EventHanDLer CanExecuteChanged;
    }

}
