using UnityEngine;

namespace ShootEmUp
{
    public sealed class DestroyCharacterControl : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        [SerializeField] private HitPointsComponent hitPointsComponent;

        private void OnEnable()
        {
            hitPointsComponent.HpIsEmpty += OnHpIsEmpty;
        }

        private void OnDisable()
        {
            hitPointsComponent.HpIsEmpty -= OnHpIsEmpty;
        }

        private void OnHpIsEmpty(GameObject character)
        {
            gameManager.FinishGame();
        }
    }
}