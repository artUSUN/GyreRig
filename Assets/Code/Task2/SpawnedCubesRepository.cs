using System.Collections.Generic;
using UnityEngine;

namespace Code.Task2
{
    public class SpawnedCubesRepository
    {
        public readonly HashSet<GameObject> Cubes = new HashSet<GameObject>();

        public void Add(GameObject cube)
        {
            Cubes.Add(cube);
        }
        
        public void Remove(GameObject cube)
        {
            Cubes.Remove(cube);
        }
    }
}