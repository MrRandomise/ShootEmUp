using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class StartButton : MonoBehaviour, IListenerGameStart, IListenerGameFinish
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Timer timer;

        public void OnButtonCLick()
        {
            StartCoroutine(timer.OnTimer());
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


