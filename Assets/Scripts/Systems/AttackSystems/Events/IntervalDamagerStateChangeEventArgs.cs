namespace Assets.Scripts.Systems.AttackSystems.Events
{
    internal class IntervalDamagerStateChangeEventArgs
    {
        public IntervalDamager Damager;
        public IntervalDamagerState NewState;
        public float StateDuration;
    }
}
