using System;

namespace MVP
{
    class Presenter
    {
        private Abstractions.IModel model;
        private Abstractions.IView view;
        public Presenter(Abstractions.IModel model, Abstractions.IView view)
        {
            this.model = model;
            this.view = view;

            this.view.OnTextChange += Display;
        }

        void Display(object sender, EventArgs e)
        {
            model.Log($"{view.CarBrand} - {view.CarNumber}");
        }
    }
}
