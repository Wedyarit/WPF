using MVC.Abstractions;
using System;
using System.Diagnostics;

namespace MVC
{
    class Model : Abstractions.IModel
    {
        void IModel.Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
