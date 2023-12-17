namespace ShootEmUp
{
    public interface IFactory<GameObject, Transform>
    {
        public GameObject Creator(GameObject prefab, Transform transform);
    }
}

