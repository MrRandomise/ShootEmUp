using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BasePool : MonoBehaviour
    {
        public int initialCount = 50;

        public Transform Container;

        public GameObject GameObjectPrefab;

        public Transform WorldTransform;

        protected readonly HashSet<GameObject> ActivePools = new();

        protected readonly Queue<GameObject> OnPoll = new();

        protected readonly List<GameObject> Cache = new();


        public void InitialObjectInPool()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var target = Instantiate(GameObjectPrefab, Container);
                OnPoll.Enqueue(target);
            }
        }

        public void RemoveObjectInPool(GameObject obj)
        {
            if (ActivePools.Remove(obj))
            {
                obj.transform.SetParent(Container);
                OnPoll.Enqueue(obj);
            }
        }
    }
}
