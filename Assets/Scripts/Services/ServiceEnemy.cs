using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceEnemy
    {
        public GameObject EnemyPrefab;

        public GameObject Character;

        public Transform EnemyContainer;

        public Transform WorldTransform;
    }
}

