using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    [RequireComponent(typeof(ListenerInstaller))]

    public class ListenerManager : MonoBehaviour
    {
        [SerializeField] private ListenerInstaller listenerInstaller;

        private void Awake()
        {
            var listener = GetComponentsInChildren<IGameListener>();

            foreach (var gameListeners in listener)
            {
                listenerInstaller.AddListener(gameListeners);
            }
        }
    }
}
