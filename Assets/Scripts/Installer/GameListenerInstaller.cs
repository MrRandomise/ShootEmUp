using Zenject;

namespace ShootEmUp
{
    public sealed class GameListenerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ListenerManager>().AsSingle();
            Container.Bind<GameManager>().AsSingle();
        }
    }
}
