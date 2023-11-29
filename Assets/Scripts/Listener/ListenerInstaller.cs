using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class ListenerInstaller : MonoBehaviour
    {
        private List<Listeners.IGameListener> listeners = new();

        public void AddListener(Listeners.IGameListener listener)
        {
            listeners.Add(listener);
        }

        private void Update()
        {
            foreach (var gameListener in listeners)
            {
                if(gameListener is Listeners.IListenerUpdate Listener)
                    Listener.OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IListenerFixUpdate Listener)
                    Listener.OnFixUpdate();
            }
        }

        public void OnStart()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IListenerStart Listener)
                    Listener.OnStart();
            }
        }

        public void OnStop()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IListenerStop Listener)
                    Listener.OnStop();
            }
        }
        public void OnResume()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IListenerResume Listener)
                    Listener.OnResume();
            }
        }

        public void OnPause()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IListenerPause Listener)
                    Listener.OnPause();
            }
        }
    }
}