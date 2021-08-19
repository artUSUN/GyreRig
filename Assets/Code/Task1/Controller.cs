namespace Code.Task1
{
    public class Controller
    {
        private readonly Model _model;
        
        public Controller(Model model)
        {
            _model = model;
        }

        public void HandleButtonClick()
        {
            _model.IncrementClickCount();
        }
    }
}