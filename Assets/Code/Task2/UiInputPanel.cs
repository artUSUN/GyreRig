using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Task2
{
    public class UiInputPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField speedInputField;
        [SerializeField] private TMP_InputField distanceInputField;
        [SerializeField] private TMP_InputField respawnDurationInputField;

        private CubeParametersController _cubeParametersController;
        
        public void Inject(CubeParametersController cubeParametersController)
        {
            _cubeParametersController = cubeParametersController;
        }

        private void Start()
        {
            speedInputField.onValueChanged.AddListener(OnSpeedChanged);
            distanceInputField.onValueChanged.AddListener(OnDistanceChanged);
            respawnDurationInputField.onValueChanged.AddListener(OnRespawnDurationChanged);
        }

        private void OnDestroy()
        {
            speedInputField.onValueChanged.RemoveListener(OnSpeedChanged);
            distanceInputField.onValueChanged.RemoveListener(OnDistanceChanged);
            respawnDurationInputField.onValueChanged.RemoveListener(OnRespawnDurationChanged);
        }

        private void OnSpeedChanged(string value)
        {
            var isValidInput = _cubeParametersController.HandleNewSpeedInput(value);

            speedInputField.textComponent.color = isValidInput ? Color.grey : Color.red;
        }
        
        private void OnDistanceChanged(string value)
        {
            var isValidInput = _cubeParametersController.HandleNewDistanceInput(value);
            
            distanceInputField.textComponent.color = isValidInput ? Color.grey : Color.red;

        }
        
        private void OnRespawnDurationChanged(string value)
        {
            var isValidInput = _cubeParametersController.HandleNewRespawnDurationInput(value);
            
            respawnDurationInputField.textComponent.color = isValidInput ? Color.grey : Color.red;
        }
    }
}