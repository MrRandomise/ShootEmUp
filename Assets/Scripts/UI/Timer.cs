using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public sealed class Timer : ITickable
    {
        private float timerInt = 3;
        private TMP_Text timerText;
        private Button pauseButton;
        private GameManager gameManager;
        public bool StartTimer = false;

        public Timer(ServiceUi serviceUi, GameManager manager)
        {
            timerInt = serviceUi.TimerInt;
            timerText = serviceUi.TimerText;
            pauseButton = serviceUi.PauseButton;
            gameManager = manager;
        }

        public void Tick()
        {
            if (timerInt > 1 && StartTimer)
            {
                timerInt -= Time.deltaTime;
                SetTimer(Mathf.Round(timerInt));
            }
            else if (timerInt < 1 && StartTimer)
            {
                StartTimer = false;
                timerText.gameObject.SetActive(false);
                pauseButton.gameObject.SetActive(true);
                gameManager.OnGameStart();
            }
        }

        private void SetTimer(float time)
        {
            timerText.text = time.ToString();
        }
    }
}

