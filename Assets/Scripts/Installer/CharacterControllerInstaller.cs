using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterControllerInstaller : MonoInstaller
    {
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private ServiceCharacter serviceCharacter;

        public override void InstallBindings()
        {
            Container.Bind<BulletConfig>().FromInstance(bulletConfig).AsSingle();
            Container.Bind<ServiceCharacter>().FromInstance(serviceCharacter).AsSingle();

            Container.Bind<DestroyCharacterControl>().AsSingle().NonLazy();
            Container.Bind<MoveCharacterControl>().AsSingle().NonLazy();
            Container.Bind<FireCharacterControl>().AsSingle().NonLazy();

            Container.Bind<InputMoveControl>().AsSingle();
            Container.Bind<InputFireControl>().AsSingle();
        }
    }
}
