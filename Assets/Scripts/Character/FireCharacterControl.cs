using UnityEngine;
namespace ShootEmUp
{
public class FireCharacterControl : MonoBehaviour, IListenerEnable, IListenerDisabled
{
        [SerializeField] private CharacterController characterController;
        [SerializeField] private BulletConfig bulletConfig;

        public void OnListenerEnable()
        {
            characterController.inputControl.OnFireAction += OnAtack;
        }

        public void OnListenerDisabled()
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