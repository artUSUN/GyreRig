using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Task2
{
    [RequireComponent(typeof(Renderer))]
    public class Cube : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}