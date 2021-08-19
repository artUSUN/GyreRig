using UnityEngine;

namespace Code.Task1
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private View view;
        
        private void Awake()
        {
            var model = new Model();
            
            var controller = new Controller(model);
            
            view.Inject(model, controller);
        }
    }
}