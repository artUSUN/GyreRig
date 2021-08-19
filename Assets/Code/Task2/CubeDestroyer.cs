using System.Collections.Generic;
using Code.Task2.Utils;
using UnityEngine;

namespace Code.Task2
{
    public class CubeDestroyer
    {
        private readonly Vector3 _spawnPosition;
        private readonly SimplePool _cubePool;
        private readonly SpawnedCubesRepository _spawnedCubesRepository;

        private readonly List<GameObject> _cubesToDestroy = new List<GameObject>();
        
        private float _squaredDistanceToDestroy = 0;
        
        public CubeDestroyer(
            Vector3 spawnPosition, 
            SimplePool cubePool, 
            SpawnedCubesRepository spawnedCubesRepository)
        {
            _spawnPosition = spawnPosition;
            _spawnedCubesRepository = spawnedCubesRepository;
            _cubePool = cubePool;
            
            MonoRunner.OnUpdate += OnUpdate;
        }

        public void ChangeDistanceToDestroyValue(float newValue)
        {
            _squaredDistanceToDestroy = newValue * newValue;
            CheckNeedDestroy();
        }

        private void OnUpdate()
        {
            CheckNeedDestroy();
        }

        private void CheckNeedDestroy()
        {
            foreach (var cube in _spawnedCubesRepository.Cubes)
            {
                var sqrDistance = cube.transform.position.DistanceSquared(_spawnPosition);
                
                if (sqrDistance < _squaredDistanceToDestroy)
                    continue;
                
                _cubesToDestroy.Add(cube);
            }

            foreach (var cube in _cubesToDestroy)
            {
                _cubePool.Despawn(cube);
                _spawnedCubesRepository.Remove(cube);
            }
            
            _cubesToDestroy.Clear();
        }
    }
}