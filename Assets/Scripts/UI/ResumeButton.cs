using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class ResumeButton : IListenerGameResume, IListenerGameFinish
    {
        private Button pauseButton;
        private Button resumeButton;
        private GameManager gameManager;

        public ResumeButton(ServiceUi serviceUI, GameManager manager)
        {
            pauseButton = serviceUI.PauseButton;
            resumeButton = serviceUI.ResumeButton;
            gameManager = manager;
            ListenerManager.Listeners.Add(this);
        }

        public void OnGameResume()
        {
            resumeButton.onClick.AddListener(OnClickResumeButton);
        }

        public void OnClickResumeButton()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            gameManager.OnGameResume();
        }

        public void OnGameFinish()
        {
            resumeButton.onClick.RemoveListener(OnClickResumeButton);
            resumeButton.gameObject.SetActive(false);
        }
    }
}
