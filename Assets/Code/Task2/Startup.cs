using Code.Task2.Utils;
using UnityEngine;

namespace Code.Task2
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private int poolWarmUpCount = 100;

        [SerializeField] private UiInputPanel inputPanel;

        private void Awake()
        {
            var simpleCubePool = new SimplePool(cubePrefab, poolWarmUpCount);
            var repository = new SpawnedCubesRepository();

            var mover = new CubeMover(repository);

            var startPosition = startPoint.position;
            
            var spawner = new CubeSpawner(startPosition, simpleCubePool, repository);
            var destroyer = new CubeDestroyer(startPosition, simpleCubePool, repository);

            var controller = new CubeParametersController(spawner, mover, destroyer);
            
            inputPanel.Inject(controller);
        }
    }
}