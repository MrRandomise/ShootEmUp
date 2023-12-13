using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceBullet
    {
        public GameObject BulletPrefab;

        public Transform BulletContainer;

        public Transform WorldTransform;
    }
}

