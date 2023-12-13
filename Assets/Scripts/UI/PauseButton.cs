using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class PauseButton : IListenerGamePause, IListenerGameFinish
    {
        private Button pauseButton;
        private Button resumeButton;
        private GameManager gameManager;

        public PauseButton(ServiceUi serviceUI, GameManager manager)
        {
            pauseButton = serviceUI.PauseButton;
            resumeButton = serviceUI.ResumeButton;
            gameManager = manager;
            ListenerManager.Listeners.Add(this);
        }

        public void OnGamePause()
        {
            pauseButton.onClick.AddListener(OnClickPauseButton);
        }

        public void OnClickPauseButton()
        {
            resumeButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            gameManager.OnGamePause();
        }

        public void OnGameFinish()
        {
            pauseButton.onClick.RemoveListener(OnClickPauseButton);
            pauseButton.gameObject.SetActive(false);
        }
    }
}

