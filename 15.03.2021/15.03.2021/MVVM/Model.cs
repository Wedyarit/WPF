using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MVVM
{
    class Model : Abstractions.IModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Show(string message)
        {
            Debug.WriteLine(message);
            OnPropertyChange();
        }
    }
}
