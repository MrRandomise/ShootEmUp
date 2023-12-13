using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class StartButton : IListenerGameStart, IListenerGameFinish
    {
        private Button startButton;
        private Timer timer;

        public StartButton(ServiceUi serviceUI, Timer startTimer)
        {
            startButton = serviceUI.StartButton;
            timer = startTimer;
            ListenerManager.Listeners.Add(this);
        }

        public void OnButtonCLick()
        {
            timer.StartTimer = true;
            startButton.gameObject.SetActive(false);
        }

        public void OnGameStart()
        {
            startButton.onClick.AddListener(OnButtonCLick);
        }

        public void OnGameFinish()
        {
            startButton.onClick.RemoveListener(OnButtonCLick);
        }
    }
}


