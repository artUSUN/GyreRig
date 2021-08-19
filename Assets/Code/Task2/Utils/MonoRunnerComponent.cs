using System;
using UnityEngine;

namespace Code.Task2
{
    public class MonoRunnerComponent : MonoBehaviour
    {
        private Action _updateCallback;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void AddCallbacks(Action updateCallback)
        {
            _updateCallback = updateCallback;
        }

        private void Update()
        {
            _updateCallback.Invoke();
        }
    }
}