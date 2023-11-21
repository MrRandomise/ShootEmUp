using UnityEngine;
namespace ShootEmUp
{
public class FireCharacterControl : MonoBehaviour
{
        [SerializeField] private CharacterController characterController;

        private void OnEnable()
        {
            characterController.inputManager.OnFireAction += OnFire;
        }

        private void OnDisable()
        {
            characterController.inputManager.OnFireAction -= OnFire;
        }
        
        private void OnFire()
        {
            
        }
    }
}