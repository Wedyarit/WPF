using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Abstractions
{
    interface IView
    {
        string CarBrand { get; set; }
        string CarNumber { get; set; }
        void AddCar();
        event EventHandler OnTextChange;
    }
}
