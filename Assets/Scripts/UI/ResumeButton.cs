using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class ResumeButton : MonoBehaviour, IListenerGameResume, IListenerGameFinish
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;

        public void OnGameResume()
        {
            resumeButton.onClick.AddListener(OnClickResumeButton);
        }

        public void OnClickResumeButton()
        {
            gameManager.OnGameResume();
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }

        public void OnGameFinish()
        {
            resumeButton.onClick.RemoveListener(OnClickResumeButton);
            resumeButton.gameObject.SetActive(false);
        }
    }
}
