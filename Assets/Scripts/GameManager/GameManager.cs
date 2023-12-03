using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public enum GameStatus
        {
            none,
            Start,
            Stop,
            Pause,
            Resume
        }

        [SerializeField] ListenerManager listenerManager;
        [SerializeField] ListenerInstaller listenerInstaller;

        public GameStatus Status { get; private set; }

        public void OnGameStart()
        {
            Status = GameStatus.Start;
            listenerManager.InitMonoBehaviorStart(listenerInstaller.Listeners);
            Debug.Log("Game start!");
            Time.timeScale = 1;
        }

        public void OnGamePause()
        {
            Status = GameStatus.Pause;
            Debug.Log("Game pause!");
            Time.timeScale = 0;
        }

        public void OnGameResume()
        {
            Status = GameStatus.Resume;
            Debug.Log("Game resume!");
            Time.timeScale = 1;
        }

        public void OnGameStop()
        {
            Status = GameStatus.Stop;
            Debug.Log("Game over!");
            listenerManager.OnGameFinish(listenerInstaller.Listeners);
            Time.timeScale = 0;
        }
    }
}