using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class ServiceCharacter
    {
        public GameObject Character;

        public WeaponComponent CharacterWeaponComponent;

        public HitPointsComponent CharacterHitPointsComponent;

        public MoveComponent CharacterMoveComponent;
    }
}

