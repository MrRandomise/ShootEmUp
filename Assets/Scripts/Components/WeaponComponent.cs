using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public Transform FirePoint;

        public WeaponLogick WeaponLogick;

        [Inject]
        private void Construcrt(BulletSystem bulletSystem)
        {
            WeaponLogick = new WeaponLogick(this, bulletSystem);
        }
    }
}