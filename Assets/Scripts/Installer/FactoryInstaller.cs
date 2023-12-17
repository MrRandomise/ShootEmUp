using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().NonLazy();
        }
    }
}
