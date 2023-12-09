using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private int timerInt = 3;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private Button pauseButton;
        [SerializeField] private GameManager gameManager;

        private int timeOneSecond = 1;

        public IEnumerator OnTimer()
        {
            while (timerInt != 0)
            {
                SetTimer(timerInt);
                timerInt--;
                yield return new WaitForSeconds(timeOneSecond);
            }
            timerText.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            gameManager.OnGameStart();
        }

        private void SetTimer(int time)
        {
            timerText.text = time.ToString();
        }
    }
}

