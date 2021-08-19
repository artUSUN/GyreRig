using Code.Task2.Utils;
using UnityEngine;

namespace Code.Task2
{
    public class CubeMover
    {
        private readonly SpawnedCubesRepository _spawnedCubesRepository;

        private float _speed = 0;

        public CubeMover(SpawnedCubesRepository spawnedCubesRepository)
        {
            _spawnedCubesRepository = spawnedCubesRepository;
            
            MonoRunner.OnUpdate += OnUpdate;
        }

        public void ChangeMoveSpeed(float newValue)
        {
            _speed = newValue;
        }
        
        private void OnUpdate()
        {
            Move();
        }

        private void Move()
        {
            foreach (var cube in _spawnedCubesRepository.Cubes)
            {
                cube.transform.Translate(Vector3.left * (_speed * Time.deltaTime));
            }
        }
    }
}