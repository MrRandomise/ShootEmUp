using UnityEngine;

namespace ShootEmUp
{
    public sealed class DestroyCharacterControl : MonoBehaviour, IListenerEnabled, IListenerDisabled
    {
        [SerializeField] private GameManager gameManager;

        [SerializeField] private HitPointsComponent hitPointsComponent;

        public void ListenerEnabled()
        {
            hitPointsComponent.OnHpIsEmpty += OnHpIsEmpty;
        }

        public void ListenerDisabled()
        {
            hitPointsComponent.OnHpIsEmpty -= OnHpIsEmpty;
        }

        private void OnHpIsEmpty(GameObject character)
        {
            gameManager.OnGameStop();
        }
    }
}