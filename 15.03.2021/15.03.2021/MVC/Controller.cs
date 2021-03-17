
namespace MVC
{
    class Controller
    {
        private Model model;
        private View view;
        
        public Controller()
        {
            model = new Model();
            view = new View();
        }
    }
}
