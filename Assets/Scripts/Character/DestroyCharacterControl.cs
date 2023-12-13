using UnityEngine;

namespace ShootEmUp
{
    public sealed class DestroyCharacterControl : IListenerEnabled, IListenerDisabled
    {
        private GameManager gameManager;

        private HitPointsComponent hitPointsComponent;

        public DestroyCharacterControl(GameManager manager, ServiceCharacter serviceCharacter)
        {
            gameManager = manager;
            hitPointsComponent = serviceCharacter.CharacterHitPointsComponent;
            ListenerManager.Listeners.Add(this);
        }

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