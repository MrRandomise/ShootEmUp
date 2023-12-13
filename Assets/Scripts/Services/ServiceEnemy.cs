using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

