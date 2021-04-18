using MVC.Abstractions;
using System;

namespace MVC
{
    class View : Abstractions.IView
    {
        string IView.CarBrand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IView.CarNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        event EventHandler IView.OnTextChange
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IView.AddCar()
        {
            throw new NotImplementedException();
        }
    }
}
