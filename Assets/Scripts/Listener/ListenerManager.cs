using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class ListenerManager : MonoBehaviour
    {
        [SerializeField] private ListenerInstaller ListenerInstaller;
        [SerializeField] private GameManager gameManager;

        public void InitMonoBehaviorStart(List<IGameListener> list)
        {
            OnLisnterEnabled(list);
            OnAwake(list);
            OnStart(list);
        }

        private bool ResumeControl()
        {
            if (gameManager.Status == GameManager.GameStatus.Start || gameManager.Status == GameManager.GameStatus.Resume)
            {
                return true;
            }
            return false;
        }

        private void Update()
        {
            if(ResumeControl())
            {
                OnUpdate(ListenerInstaller.listenerUpdates);
            }
        }

        public void FixedUpdate()
        {
            if (ResumeControl())
            {
                OnFixUpdate(ListenerInstaller.listenerFixUpdates);
            }
        }

        private void OnDisable()
        {
            OnLisnterDisabled(ListenerInstaller.Listeners);
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

        public void OnLisnterEnabled(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerEnabled listener)
                {
                    listener.ListnerEnabled();
                }
            }
        }

        public void OnLisnterDisabled(List<IGameListener> list)
        {
            foreach (var gameListener in list)
            {
                if (gameListener is IListenerDisabled listener)
                {
                    listener.ListnerDisabled();
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

