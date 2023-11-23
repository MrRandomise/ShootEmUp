using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDestroyController: MonoBehaviour, IListenerEnable, IListenerDisabled
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private GameManager gameManager;

        public void OnListenerEnable()
        {
            characterController.hitPointsComponent.HpIsEmpty += OnHpIsEmpty;
        }

        public void OnListenerDisabled()
        {
            characterController.hitPointsComponent.HpIsEmpty -= OnHpIsEmpty;
        }
        

        private void OnHpIsEmpty(GameObject character)
        {
            gameManager.FinishGame();
        }
    }
}