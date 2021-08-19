using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Task1
{
    public class View : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;
        [SerializeField] private Button button;

        private Model _model;
        private Controller _controller;
        
        public void Inject(Model model, Controller controller)
        {
            _model = model;
            _controller = controller;
        }

        private void Start()
        {
            _model.ClickCountIncremented += ClickCountIncremented;
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            _model.ClickCountIncremented -= ClickCountIncremented;
            button.onClick.RemoveListener(OnButtonClicked);
        }

        private void ClickCountIncremented(int newClickCount)
        {
            tmp.text = newClickCount.ToString();
        }

        private void OnButtonClicked()
        {
            _controller.HandleButtonClick();
        }
    }
}
