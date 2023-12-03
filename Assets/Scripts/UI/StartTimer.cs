using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class StartTimer : MonoBehaviour, IListenerGameStart, IListenerGameFinish
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private int timerInt = 3;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button startButton;
        [SerializeField] private GameManager gameManager;

        public void OnButtonCLick()
        {
            StartCoroutine(Timer());
            startButton.gameObject.SetActive(false);
        }

        IEnumerator Timer()
        {
            while (timerInt != 0)
            {
                SetTimer(timerInt);
                timerInt--;
                yield return new WaitForSeconds(1);
            }
            timerText.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            gameManager.OnGameStart();
        }

        public void OnGameStart()
        {
            startButton.onClick.AddListener(OnButtonCLick);
        }

        public void OnGameFinish()
        {
            startButton.onClick.RemoveListener(OnButtonCLick);
        }

        private void SetTimer(int time)
        {
            timerText.text = time.ToString();
        }
    }
}


