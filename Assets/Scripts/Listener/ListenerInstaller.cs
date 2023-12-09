using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class ListenerInstaller : MonoBehaviour
    {
        public enum GameStatus
        {
            none,
            Start,
            Stop,
            Pause,
            Resume
        }

        [SerializeField] private ListenerManager listenerManager;

        [SerializeField] private List<GameObject> listenersInScene = new List<GameObject>();

        public readonly List<IListenerUpdate> ListenerUpdates = new List<IListenerUpdate>();

        public readonly List<IListenerFixUpdate> ListenerFixUpdates = new List<IListenerFixUpdate>();

        public List<IGameListener> Listeners = new List<IGameListener>();

        private List<IGameListener> DynamicListeners = new List<IGameListener>();

        public GameStatus Status;


        private void Awake()
        {
            foreach (var gameListener in listenersInScene)
            {
                GetLisnters(gameListener);
            }
            listenerManager.OnGameStart(Listeners);
            listenerManager.OnGameResume(Listeners);
            listenerManager.OnGamePause(Listeners);
        }

        public void InitMonoBehaviorStart(List<IGameListener> list)
        {
            listenerManager.OnListenerEnabled(list);
            listenerManager.OnAwake(list);
            listenerManager.OnStart(list);
        }

        public void InitStopGame()
        {
            listenerManager.OnGameFinish(Listeners);
        }

        public void AddDynamicLisnter(GameObject data)
        {
            foreach (var componentLisnter in data.GetComponentsInChildren<IGameListener>())
            {
                GetTypeListener(componentLisnter);
                DynamicListeners.Add(componentLisnter);
            }
            InitMonoBehaviorStart(DynamicListeners);
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
                    ListenerUpdates.Add(listenerUpdate);
                    break;
                case IListenerFixUpdate listenerFixUpdate:
                    ListenerFixUpdates.Add(listenerFixUpdate);
                    break;
                default:
                    break;
            }
        }
    }
}