using UnityEngine;

namespace ShootEmUp
{
    public sealed class DestroyCharacterControl : MonoBehaviour, Listeners.IListenerStart, Listeners.IListenerStop
    {
        [SerializeField] private GameManager gameManager;

        [SerializeField] private HitPointsComponent hitPointsComponent;

        public void OnStart()
        {
            hitPointsComponent.OnHpIsEmpty += OnHpIsEmpty;
        }

        public void OnStop()
        {
            hitPointsComponent.OnHpIsEmpty -= OnHpIsEmpty;
        }

        private void OnHpIsEmpty(GameObject character)
        {
            gameManager.FinishGame();
        }
    }
}