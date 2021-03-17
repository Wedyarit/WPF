using System;

namespace MVVM.Abstractions
{
    interface IView
    {
        string CarBrand { get; set; }
        string CarNumber { get; set; }
        void AddCar();
        event EventHandler OnTextChange;
    }
}
