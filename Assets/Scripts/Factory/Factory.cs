using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class Factory : IFactory<GameObject, Transform>
    {
        private DiContainer diContainer;

        public Factory(DiContainer container)
        {
            diContainer = container;
        }

        public GameObject Creator(GameObject prefab, Transform transform)
        {
            var obj = diContainer.InstantiatePrefab(prefab, transform);
            return obj;
        }
    }
}

