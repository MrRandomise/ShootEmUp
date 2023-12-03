using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GameControllButton : MonoBehaviour, IListenerGamePause, IListenerGameFinish
    {
        [SerializeField] GameManager gameManager;
        [SerializeField] TMP_Text buttonText;
        [SerializeField] Button button;

        private const string resumeText = "œ–ŒƒŒÀ∆»“‹";
        private const string pauseText = "œ¿”«¿";

        public void OnGamePause() 
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void OnGameFinish()
        {
            button.onClick.RemoveListener(OnButtonClick);
            this.gameObject.SetActive(false);
        }

        public void OnButtonClick()
        {
            if (gameManager.Status == GameManager.GameStatus.Resume || gameManager.Status == GameManager.GameStatus.Start)
            {
                buttonText.text = resumeText;
                gameManager.OnGamePause();
            }
            else if  (gameManager.Status == GameManager.GameStatus.Pause)
            {
                buttonText.text = pauseText;
                gameManager.OnGameResume();
            }
        }
    }
}
