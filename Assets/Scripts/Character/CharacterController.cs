using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] public ControlInput inputControl;
        [SerializeField] public GameObject character;
        [NonSerialized] public MoveComponent moveComponent;
        [NonSerialized] public WeaponComponent weaponComponent;
        [NonSerialized] public HitPointsComponent hitPointsComponent;
        
        private void Awake()
        {
            moveComponent = character.GetComponent<MoveComponent>();
            weaponComponent = character.GetComponent<WeaponComponent>();
            hitPointsComponent = character.GetComponent<HitPointsComponent>();
        }
    }
}
