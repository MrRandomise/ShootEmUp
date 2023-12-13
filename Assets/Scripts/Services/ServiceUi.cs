using System;
using TMPro;
using UnityEngine.UI;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceUi
    {
        public int TimerInt = 3;
        public Button StartButton;
        public Button PauseButton;
        public Button ResumeButton;
        public TMP_Text TimerText;
    }
}

