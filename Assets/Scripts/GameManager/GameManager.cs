using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager
    {
        private ListenerManager listenerManager;

        public GameManager (ListenerManager manager)
        {
            listenerManager = manager;
        }

        public void OnGameStart()
        {
            listenerManager.Status = ListenerManager.GameStatus.Start;
            listenerManager.InitMonoBehaviorStart(ListenerManager.Listeners);
            Debug.Log("Game start!");
            Time.timeScale = 1;
        }

        public void OnGamePause()
        {
            listenerManager.Status = ListenerManager.GameStatus.Pause;
            Debug.Log("Game pause!");
            Time.timeScale = 0;
        }

        public void OnGameResume()
        {
            listenerManager.Status = ListenerManager.GameStatus.Resume;
            Debug.Log("Game resume!");
            Time.timeScale = 1;
        }

        public void OnGameStop()
        {
            listenerManager.Status = ListenerManager.GameStatus.Stop;
            Debug.Log("Game over!");
            listenerManager.OnGameFinish();
            Time.timeScale = 0;
        }
    }
}