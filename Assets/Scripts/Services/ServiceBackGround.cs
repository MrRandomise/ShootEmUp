using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceBackGround
    {
        public float StartPositionY;

        public float EndPositionY;

        public float MovingSpeedY;

        public Transform BackGround;
    }
}

