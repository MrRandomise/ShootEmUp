namespace ShootEmUp
{
    public interface IListenerUpdate : IGameListener
    {
        public void OnUpdate(float deltaTime);
    }
}