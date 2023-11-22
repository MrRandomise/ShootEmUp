using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDestroyController: MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private GameManager gameManager;

        private void OnEnable()
        {
            characterController.hitPointsComponent.HpIsEmpty += OnHpIsEmpty;
        }

        private void OnDisable()
        {
            characterController.hitPointsComponent.HpIsEmpty -= OnHpIsEmpty;
        }

        private void OnHpIsEmpty(GameObject character)
        {
            gameManager.FinishGame();
        }
    }
}