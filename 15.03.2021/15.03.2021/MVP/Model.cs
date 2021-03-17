using MVP.Abstractions;
using System.Diagnostics;

namespace MVP
{
    class Model : Abstractions.IModel
    {
        void IModel.Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
