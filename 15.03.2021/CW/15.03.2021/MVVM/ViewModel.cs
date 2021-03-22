using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        private readonly Abstractions.IModel model;
        private string carBrand;
        private string carNumber;

        public string CarBrand { get => carBrand; set { carBrand = value; OnPropertyChange(); }}
        public string CarNumber { get => carNumber; set { carNumber = value; OnPropertyChange(); } }

        public ViewModel()
        {
            model = new Model();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            model.Show($"{CarBrand} - {CarNumber}");
        }
    }
}
