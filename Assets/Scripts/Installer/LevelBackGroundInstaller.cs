using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBackGroundInstaller : MonoInstaller
    {
        [SerializeField] private ServiceBackGround serviceBackGround;

        public override void InstallBindings()
        {
            Container.Bind<ServiceBackGround>().FromInstance(serviceBackGround).AsSingle();

            Container.Bind<LevelBackground>().AsSingle().NonLazy();
        }
    }
}