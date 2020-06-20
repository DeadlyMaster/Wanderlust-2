using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Wanderlust.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //check if property changed is not null, check if someone is listening -> if it is than notify it 
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // implement RaisePropertyChanged

        public virtual void Initialize (object parameter)
        {

        }
    }

}
