using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Pool
    {
        protected int initialCount = 7;

        protected Transform Container;

        protected Transform WorldTransform;

        protected readonly HashSet<GameObject> ActivePools = new();

        protected readonly Queue<GameObject> OnPoll = new();

        protected readonly List<GameObject> Cache = new();

        protected ListenerManager ListenerManager;

        protected void InitialObjectInPool(GameObject GameObjectPrefab)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var ObjectInPool = MonoBehaviour.Instantiate(GameObjectPrefab, Container);
                ListenerManager.AddDynamicLisnter(ObjectInPool);
                OnPoll.Enqueue(ObjectInPool);
            } 
        }


        protected void RemoveObjectInPool(GameObject obj)
        {
            if (ActivePools.Remove(obj))
            {
                obj.transform.SetParent(Container);
                OnPoll.Enqueue(obj);
            }
        }
    }
}