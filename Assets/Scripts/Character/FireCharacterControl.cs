using UnityEngine;
namespace ShootEmUp
{
public class FireCharacterControl : MonoBehaviour
{
        [SerializeField] private CharacterController characterController;
        [SerializeField] private BulletConfig bulletConfig;

        private void OnEnable()
        {
            characterController.inputControl.OnFireAction += OnAtack;
        }

        private void OnDisable()
        {
            characterController.inputControl. OnFireAction -= OnAtack;
        }
        
        private void OnAtack()
        {
            characterController.weaponComponent.OnWeaponAtack(new Args
            {
                isPlayer = true,
                physicsLayer = (int) PhysicsLayer.PLAYER_BULLET,
                color = Color.blue,
                damage = 1,
                position = characterController.weaponComponent.Position,
                velocity = characterController.weaponComponent.Rotation * Vector3.up * bulletConfig.speed
            });
        }
    }
}