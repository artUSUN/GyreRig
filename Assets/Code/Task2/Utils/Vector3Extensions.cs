using UnityEngine;

namespace Code.Task2.Utils
{
    public static class Vector3Extensions
    {
        public static float DistanceSquared(this Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).sqrMagnitude;
        }
    }
}