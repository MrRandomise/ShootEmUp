using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField] private ServiceUi serviceUI;

        public override void InstallBindings()
        {
            Container.Bind<ServiceUi>().FromInstance(serviceUI).AsSingle();

            Container.Bind<PauseButton>().AsSingle().NonLazy();
            Container.Bind<ResumeButton>().AsSingle().NonLazy();
            Container.Bind<StartButton>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<Timer>().AsSingle();
        }
    }
}
