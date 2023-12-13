using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceEnemyPosition
    {
        public Transform[] SpawnPositions;

        public Transform[] AttackPositions;
    }
}

