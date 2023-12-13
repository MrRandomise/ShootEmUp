using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace ShootEmUp
{
    public sealed class ListenerManager : ITickable, IFixedTickable, IInitializable
    {
        public enum GameStatus
        {
            none,
            Start,
            Stop,
            Pause,
            Resume
        }
        public static List<IGameListener> Listeners = new List<IGameListener>();

        private List<IListenerUpdate> ListenerUpdates = new List<IListenerUpdate>();

        private List<IListenerFixUpdate> ListenerFixUpdates = new List<IListenerFixUpdate>();

        private List<IGameListener> DynamicListeners = new List<IGameListener>();

        public GameStatus Status;

        public void Initialize() 
        {
            
            foreach (var listener in Listeners)
            {
                GetTypeListener(listener);
            }
            OnGameStart();
            OnGameResume();
            OnGamePause();
        }

        public void InitMonoBehaviorStart(List<IGameListener> list)
        {
            OnListenerEnabled(list);
            OnAwake(list);
            OnStart(list);
            OnEnumStart(list);
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

        private void GetTypeListener(IGameListener list)
        {
            switch (list)
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

        private bool ResumeControl()
        {
            if (Status == GameStatus.Start || Status == GameStatus.Resume)
            {
                return true;
            }
            return false;
        }

        public void Tick()
        {
            if(ResumeControl())
            {
                OnUpdate(ListenerUpdates);
            }
        }

        public void FixedTick()
        {
            if (ResumeControl())
            {
                OnFixUpdate(ListenerFixUpdates);
            }
        }

        public void OnAwake(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if(gameListener is IListenerAwake listener)
                {
                    listener.OnAwake();
                }   
            }
        }

        public void OnStart(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerStart listener)
                {
                    listener.OnStart();
                }
            }
        }

        public void OnEnumStart(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerEnumStart listener)
                {
                    listener.OnEnumStart();
                }
            }
        }

        public void OnUpdate(List<IListenerUpdate> list)
        {
            var deltaTime = Time.deltaTime;

            for (int i = 0; i < list.Count; i++)
            {
                list[i].OnUpdate(deltaTime);
            }
        }

        public void OnFixUpdate(List<IListenerFixUpdate> list)
        {
            var deltaTime = Time.deltaTime;

            for (int i = 0; i < list.Count; i++) 
            {
                list[i].OnFixUpdate(deltaTime);
            }
        }

        public void OnListenerEnabled(List<IGameListener> list)
        {
            foreach (var gameListener in Listeners)
            {
                if (gameListener is IListenerEnabled listener)
                {
                    listener.ListenerEnabled();
                }
            }
        }

        public void OnListenerDisabled(List<IGameListener> list)
        {
            foreach (var gameListener in Listeners)
            {
                if (gameListener is IListenerDisabled listener)
                {
                    listener.ListenerDisabled();
                }
            }
        }

        public void OnGameStart()
        {
            foreach (var gameListener in Listeners)
            {
                if (gameListener is IListenerGameStart listener)
                {
                    listener.OnGameStart();
                }
            }
        }

        public void OnGameResume()
        {
            foreach (var gameListener in Listeners)
            {
                if (gameListener is IListenerGameResume listener)
                {
                    listener.OnGameResume();
                }
            }
        }

        public void OnGamePause()
        {
            foreach (var gameListener in Listeners)
            {
                if (gameListener is IListenerGamePause listener)
                {
                    listener.OnGamePause();
                }     
            }
        }

        public void OnGameFinish()
        {
            foreach (var gameListener in Listeners)
            {
                if (gameListener is IListenerGameFinish listener)
                {
                    listener.OnGameFinish();
                }    
            }
        }
    }
}

