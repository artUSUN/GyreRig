using System;

namespace Code.Task1
{
    public class Model
    {
        private int clickCount;

        public event Action<int> ClickCountIncremented;
        
        public void IncrementClickCount()
        {
            clickCount++;
            ClickCountIncremented?.Invoke(clickCount);
        }
    }
}