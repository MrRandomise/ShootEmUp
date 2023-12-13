using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPositionInstaller : MonoInstaller
    {
        [SerializeField] private ServiceEnemyPosition serviceEnemyPosition;

        public override void InstallBindings()
        {
            Container.Bind<ServiceEnemyPosition>().FromInstance(serviceEnemyPosition).AsSingle();

            Container.Bind<EnemyPositions>().AsSingle();
        }
    }
}

