namespace ShootEmUp
{
    public sealed class HitPointsLogick
    {
        private HitPointsComponent hitPointsComponent;

        public HitPointsLogick(HitPointsComponent component)
        {
            hitPointsComponent = component;
        }

        public bool IsHitPointsExists()
        {
            return hitPointsComponent.HitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            hitPointsComponent.HitPoints -= damage;
            if (hitPointsComponent.HitPoints <= 0)
            {
                hitPointsComponent.BulletDamage();
            }
        }
    }
}
