using UnityEngine;

namespace ShootEmUp
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] public InputKeypboard inputManager;
        [SerializeField] public GameObject character;
        [HideInInspector] public MoveComponent moveComponent;
        [HideInInspector] public WeaponComponent weaponComponent;
        [HideInInspector] public HitPointsComponent hitPointsComponent;
        
        private void Start()
        {
            moveComponent = character.GetComponent<MoveComponent>();
            weaponComponent = character.GetComponent<WeaponComponent>();
            hitPointsComponent = character.GetComponent<HitPointsComponent>();
        }
    }
}
