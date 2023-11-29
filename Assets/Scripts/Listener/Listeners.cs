namespace ShootEmUp
{
    public class Listeners
    {
        public interface IGameListener
        {

        }

        public interface IListenerUpdate : IGameListener
        {
            public void OnUpdate();
        }

        public interface IListenerFixUpdate : IGameListener
        {
            public void OnFixUpdate();
        }

        public interface IListenerStart : IGameListener
        {
            public void OnStart();
        }

        public interface IListenerStop : IGameListener
        {
            public void OnStop();
        }

        public interface IListenerPause : IGameListener
        {
            public void OnPause();
        }

        public interface IListenerResume : IGameListener
        {
            public void OnResume();
        }
    }
}