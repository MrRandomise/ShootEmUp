using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceLevelBounds
    {
        public Transform LeftBorder;

        public Transform RightBorder;

        public Transform DownBorder;

        public Transform TopBorder;
    }
}

