using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] ListenerInstaller listenerInstaller;

        public void OnGameStart()
        {
            listenerInstaller.Status = ListenerInstaller.GameStatus.Start;
            listenerInstaller.InitMonoBehaviorStart(listenerInstaller.Listeners);
            Debug.Log("Game start!");
            Time.timeScale = 1;
        }

        public void OnGamePause()
        {
            listenerInstaller.Status = ListenerInstaller.GameStatus.Pause;
            Debug.Log("Game pause!");
            Time.timeScale = 0;
        }

        public void OnGameResume()
        {
            listenerInstaller.Status = ListenerInstaller.GameStatus.Resume;
            Debug.Log("Game resume!");
            Time.timeScale = 1;
        }

        public void OnGameStop()
        {
            listenerInstaller.Status = ListenerInstaller.GameStatus.Stop;
            Debug.Log("Game over!");
            listenerInstaller.InitStopGame();
            Time.timeScale = 0;
        }
    }
}