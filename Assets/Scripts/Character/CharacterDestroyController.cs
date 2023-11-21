using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDestroyController: MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CharacterController characterController;

        private void OnEnable()
        {
            characterController.hitPointsComponent.hpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            characterController.hitPointsComponent.hpEmpty -= this.OnCharacterDeath;
        }
        
        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}