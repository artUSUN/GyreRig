using Code.Task2.Utils;
using UnityEngine;

namespace Code.Task2
{
    public class CubeSpawner
    {        
        private readonly Vector3 _spawnPosition;
        private readonly SimplePool _cubePool;
        private readonly SpawnedCubesRepository _spawnedCubesRepository;

        private float _currentTime = 0;
        private float _respawnDuration = 0;

        public CubeSpawner(
            Vector3 spawnPosition, 
            SimplePool cubePool, 
            SpawnedCubesRepository spawnedCubesRepository)
        {
            _spawnPosition = spawnPosition;
            _cubePool = cubePool;
            _spawnedCubesRepository = spawnedCubesRepository;
            
            MonoRunner.OnUpdate += OnUpdate;
        }

        public void ChangeRespawnDuration(float newTimeInSec)
        {
            _respawnDuration = newTimeInSec;
            CheckNeedSpawn();
        }

        private void OnUpdate()
        {
            _currentTime += Time.deltaTime;
            CheckNeedSpawn();
        }

        private void CheckNeedSpawn()
        {
            if (_respawnDuration == 0) return;
            
            if (_currentTime < _respawnDuration)
                return;

            var cube = _cubePool.Spawn(_spawnPosition, Quaternion.identity);
            _spawnedCubesRepository.Add(cube);
            _currentTime = 0;
        }
    }
}