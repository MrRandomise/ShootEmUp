using UnityEngine;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class ListenerManager : MonoBehaviour
    {
        [SerializeField] private ListenerInstaller listenerInstaller;

        private bool ResumeControl()
        {
            if (listenerInstaller.Status == ListenerInstaller.GameStatus.Start || listenerInstaller.Status == ListenerInstaller.GameStatus.Resume)
            {
                return true;
            }
            return false;
        }

        private void Update()
        {
            if(ResumeControl())
            {
                OnUpdate(listenerInstaller.ListenerUpdates);
            }
        }

        public void FixedUpdate()
        {
            if (ResumeControl())
            {
                OnFixUpdate(listenerInstaller.ListenerFixUpdates);
            }
        }

        private void OnDisable()
        {
            OnListenerDisabled(listenerInstaller.Listeners);
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
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerEnabled listener)
                {
                    listener.ListenerEnabled();
                }
            }
        }

        public void OnListenerDisabled(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerDisabled listener)
                {
                    listener.ListenerDisabled();
                }
            }
        }

        public void OnGameStart(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerGameStart listener)
                {
                    listener.OnGameStart();
                }
            }
        }

        public void OnGameResume(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerGameResume listener)
                {
                    listener.OnGameResume();
                }
            }
        }

        public void OnGamePause(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerGamePause listener)
                {
                    listener.OnGamePause();
                }     
            }
        }

        public void OnGameFinish(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerGameFinish listener)
                {
                    listener.OnGameFinish();
                }    
            }
        }
    }
}

