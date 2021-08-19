using System.Collections.Generic;
using UnityEngine;

namespace Code.Task2.Utils
{
    public class SimplePool
    {
        private readonly GameObject _prefab;
        
        private readonly Transform _root;

        private readonly Queue<GameObject> _objectsInPool = new Queue<GameObject>();
        
        public SimplePool(GameObject prefab, int warmUpCount)
        {
            _prefab = prefab;

            _root = new GameObject($"{_prefab.name} pool").transform;

            WarmUp(warmUpCount);
        }

        public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var gameObject = _objectsInPool.Count == 0 
                ? Instantiate() 
                : _objectsInPool.Dequeue();
            
            var gameObjectTransform = gameObject.transform;
            
            gameObjectTransform.parent = parent;
            gameObjectTransform.position = position;
            gameObjectTransform.rotation = rotation;
            
            gameObject.SetActive(true);

            return gameObject;
        }

        public void Despawn(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.parent = _root;
            
            _objectsInPool.Enqueue(gameObject);
        }
        
        private GameObject Instantiate()
        {
            return Object.Instantiate(_prefab, _root);
        }

        private void WarmUp(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var newGameObject = Instantiate();
                Despawn(newGameObject);
            }
        }
    }
}