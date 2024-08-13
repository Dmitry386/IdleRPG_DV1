using Packages.DVParameters.Source.Mono;

namespace Assets.Scripts.Systems.Helpers
{
    internal static class HealthHelper
    {
        public static void DowngradeHealth(FloatDataParameters parameters, float damage)
        {
            if (parameters.DataContainer.GetData("Health", out var health))
            {
                parameters.DataContainer.SetData("Health", health.Value - damage);
            }
        }

        public static void AddHealth(FloatDataParameters parameters, float val)
        {
            if (parameters.DataContainer.GetData("Health", out var health))
            {
                parameters.DataContainer.SetData("Health", health.Value + val);
            }
        }

        public static bool IsDeath(FloatDataParameters health)
        {
            if (health.DataContainer.GetData("Health", out var hd))
            {
                return hd.Value <= 0;
            }

            return false;
        }

        public static float GetDamage(float damage, float armourValue)
        {
            float armourDamageDowngrade = 0;
            if (armourValue > 0) armourDamageDowngrade = (armourValue / 10);

            return damage - armourDamageDowngrade;
        }
    }
}