namespace ShootEmUp
{
    public interface IListenerFixUpdate : IGameListener
    {
        public void OnFixUpdate(float deltaTime);
    }
}