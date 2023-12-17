using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Pool
    {
        protected int initialCount = 7;

        protected readonly HashSet<GameObject> ActivePools = new();

        protected readonly Queue<GameObject> OnPoll = new();

        protected readonly List<GameObject> Cache = new();

        protected Factory PoolFactory;

        protected void InitialObjectInPool(GameObject gameObjectPrefab, Transform container)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var objectInPool = PoolFactory.Creator(gameObjectPrefab, container);
                OnPoll.Enqueue(objectInPool);
            } 
        }


        protected void RemoveObjectInPool(GameObject obj, Transform container)
        {
            if (ActivePools.Remove(obj))
            {
                obj.transform.SetParent(container);
                OnPoll.Enqueue(obj);
            }
        }
    }
}