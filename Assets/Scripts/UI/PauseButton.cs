using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PauseButton : MonoBehaviour, IListenerGamePause, IListenerGameFinish
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;

        public void OnGamePause()
        {
            pauseButton.onClick.AddListener(OnClickPauseButton);
        }

        public void OnClickPauseButton()
        {
            gameManager.OnGamePause();
            resumeButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }

        public void OnGameFinish()
        {
            pauseButton.onClick.RemoveListener(OnClickPauseButton);
            pauseButton.gameObject.SetActive(false);
        }
    }
}

