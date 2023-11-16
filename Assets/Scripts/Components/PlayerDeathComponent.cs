using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerDeathComponent: MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private void OnEnable()
        {
            this.GetComponent<HitPointsComponent>().hpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.GetComponent<HitPointsComponent>().hpEmpty -= this.OnCharacterDeath;
        }
        
        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();
    }
}
