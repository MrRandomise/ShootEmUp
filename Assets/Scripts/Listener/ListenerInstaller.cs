using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class ListenerInstaller : MonoBehaviour
    {
        [SerializeField] private ListenerManager listenerManager;

        [SerializeField] private List<GameObject> listenersInScene = new List<GameObject>();

        public  readonly List<IListenerUpdate> listenerUpdates = new List<IListenerUpdate>();

        public  readonly List<IListenerFixUpdate> listenerFixUpdates = new List<IListenerFixUpdate>();

        public List<IGameListener> Listeners = new List<IGameListener>();

        private List<IGameListener> DynamicListeners = new List<IGameListener>();

        private void Awake()
        {
            foreach (var gameListener in listenersInScene)
            {
                GetLisnters(gameListener);
            }
            InitStartGame(Listeners);
        }

        private void InitStartGame(List<IGameListener> list)
        {
            listenerManager.OnGameStart(list);
            listenerManager.OnGameResume(list);
            listenerManager.OnGamePause(list);
        }

        public void AddDynamicLisnter(GameObject data)
        {
            foreach (var componentLisnter in data.GetComponentsInChildren<IGameListener>())
            {
                GetTypeListener(componentLisnter);
                DynamicListeners.Add(componentLisnter);
            }
            listenerManager.InitMonoBehaviorStart(DynamicListeners);
            DynamicListeners.Clear();
        }

        private void GetLisnters(GameObject listner)
        {
            foreach (var componentLisnter in listner.GetComponentsInChildren<IGameListener>())
            {
                GetTypeListener(componentLisnter);
                Listeners.Add(componentLisnter);
            }
        }

        private void GetTypeListener(IGameListener list)
        {
            switch(list)
            {
                case IListenerUpdate listenerUpdate:
                    listenerUpdates.Add(listenerUpdate);
                    break;
                case IListenerFixUpdate listenerFixUpdate:
                    listenerFixUpdates.Add(listenerFixUpdate);
                    break;
                default:
                    break;
            }
        }
    }
}