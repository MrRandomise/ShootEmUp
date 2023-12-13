using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystemInstaller : MonoInstaller
    {
        [SerializeField] private ServiceBullet serviceBullet;

        public override void InstallBindings()
        {
            Container.Bind<ServiceBullet>().FromInstance(serviceBullet).AsSingle();

            Container.Bind<BulletSystem>().AsSingle().NonLazy();
            Container.Bind<BulletDamage>().AsSingle();
        }
    }
}
