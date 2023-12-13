using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ServiceEnemy sericeEnemy;
     
        public override void InstallBindings()
        {
            Container.Bind<ServiceEnemy>().FromInstance(sericeEnemy).AsSingle();

            Container.Bind<EnemyManager>().AsSingle().NonLazy();
        }
    }
}