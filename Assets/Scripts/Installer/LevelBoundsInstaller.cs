using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBoundsInstaller : MonoInstaller
    {
        [SerializeField] private ServiceLevelBounds servicesLevelBounds;

        public override void InstallBindings()
        {
            Container.Bind<ServiceLevelBounds>().FromInstance(servicesLevelBounds).AsSingle().NonLazy();

            Container.Bind<LevelBounds>().AsSingle();
        }
    }
}