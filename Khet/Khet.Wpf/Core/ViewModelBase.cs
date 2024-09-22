using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Khet.Wpf.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // PropertyChanged event to notify the UI of property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Helper method to set the value of a property and raise PropertyChanged event
        protected bool SetProperty<T>(ref T backingField, T value, bool forceUpdate = false, [CallerMemberName] string propertyName = null)
        {
            // Raise PropertyChanged even if the value is the same, when forceUpdate is true
            if (!forceUpdate && EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }



    }


}
