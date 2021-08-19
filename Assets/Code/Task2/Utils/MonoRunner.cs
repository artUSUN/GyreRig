using System;
using UnityEngine;

namespace Code.Task2.Utils
{
    public static class MonoRunner
    {
        public static event Action OnUpdate;
        
        private static MonoRunnerComponent _component;
        
        static MonoRunner()
        {
            _component = new GameObject("MonoRunner").AddComponent<MonoRunnerComponent>();
            _component.AddCallbacks(Update);
        }

        private static void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}